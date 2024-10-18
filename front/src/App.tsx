import { useEffect, useMemo, useState } from "react";

import { Field } from "./components/Field";
import { Square } from "./shared/types";
import { getSquares, addSquare } from "./api/api";

import "./App.css";
import { generateRandomHexColor } from "./shared/color.utils";
import {
  fill2dArrayWithSquares,
  findFirstEmptyCell,
} from "./shared/array.utils";

function App() {
  const [squaresState, updateSquaresState] = useState<Square[]>([]);
  const [isLoading, setLoading] = useState(false);
  const squares2d = useMemo(() => {
    if (squaresState.length === 0) {
      return [];
    }
    return fill2dArrayWithSquares(squaresState);
  }, [squaresState]);

  useEffect(() => {
    setLoading(true);
    getSquares().then((data) => {
      updateSquaresState(data.squares);
      setLoading(false);
    });
  }, []);

  const addNewSquare = (square: Square) => {
    setLoading(true);
    addSquare(square).then((data) => {
      updateSquaresState(data.squares);
      setLoading(false);
    });
  };

  const handleButtonClick = () => {
    let newSquareColor = generateRandomHexColor();

    // if we have now squares yet
    if (squaresState.length === 0) {
      return addNewSquare({
        color: newSquareColor,
        position: {
          x: 0,
          y: 0,
        },
      });
    }
    // generate until uniq color
    while (newSquareColor === squaresState[squaresState.length - 1].color) {
      newSquareColor = generateRandomHexColor();
    }

    const searchResult = findFirstEmptyCell(squares2d);

    // if search result succeed
    if (searchResult !== null) {
      const [x, y] = searchResult;
      return addNewSquare({
        color: newSquareColor,
        position: {
          x,
          y,
        },
      });
    }

    addNewSquare({
      color: newSquareColor,
      position: {
        x: squares2d.length,
        y: 0,
      },
    });
  };

  return (
    <div className="container">
      <button disabled={isLoading} onClick={handleButtonClick}>
        Lägg till ruta
      </button>
      {squaresState && <Field squares={squares2d} />}
    </div>
  );
}

export default App;

import { FunctionComponent, useEffect, useRef } from "react";
import { Array2d } from "../shared/array.utils";
import { drawSquares } from "../shared/canvas.utils";

type FieldProps = {
  squares?: Array2d;
};

export const Field: FunctionComponent<FieldProps> = ({ squares }) => {
  const canvasRef = useRef<HTMLCanvasElement | null>(null);

  useEffect(() => {
    if (squares) {
      drawSquares(canvasRef.current as HTMLCanvasElement, squares, 20, 5);
    }
  }, [squares]);

  return (
    <canvas
      style={{ border: "1px solid #0e0e0e", backgroundColor: "#42AAFF" }}
      ref={canvasRef}
      id="squares-field"
      width="400"
      height="400"
    ></canvas>
  );
};

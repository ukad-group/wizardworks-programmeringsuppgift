import { Square } from "./types";

export const createEmpty2dArray = (size: number): (null | string)[][] => {
  return Array.from({ length: size }, () => Array(size).fill(null));
};

export type Array2d = ReturnType<typeof createEmpty2dArray>;

export const fill2dArrayWithSquares = (squares: Square[]) => {
  const size = Math.ceil(Math.sqrt(squares.length));
  const result = createEmpty2dArray(size);
  squares.forEach((square) => {
    const { x, y } = square.position;
    result[y][x] = square.color;
  });

  return result;
};

export const findFirstEmptyCell = (array2d: Array2d) => {
  if (array2d[array2d.length - 1][array2d.length - 1] !== null) {
    return null;
  }

  for (let row = 0; row < array2d.length; row++) {
    for (let col = 0; col < array2d.length; col++) {
      if (array2d[row][col] === null) {
        return [col, row];
      }
    }
  }

  return null;
};

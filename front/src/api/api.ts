import { Square } from "../shared/types";

let _mockedSquares: Square[] = [
  {
    color: "red",
    position: {
      x: 0,
      y: 0,
    },
  },
  {
    color: "green",
    position: {
      x: 1,
      y: 0,
    },
  },
  {
    color: "blue",
    position: {
      x: 0,
      y: 1,
    },
  },
];

export const addSquare = (newSquare: Square) => {
  return new Promise<Square[]>((resolve) => {
    setTimeout(() => {
      _mockedSquares = [..._mockedSquares, newSquare];
      resolve(_mockedSquares);
    }, 150);
  });
};

export const getSquares = () => {
  return new Promise<Square[]>((resolve) => {
    setTimeout(() => {
      resolve(_mockedSquares);
    }, 150);
  });
};

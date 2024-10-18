import { Square } from "../shared/types";

const API_URL =
  "https://wizardworksdemoapi-api.orangegrass-e973561e.westeurope.azurecontainerapps.io";

// let _mockedSquares: Square[] = [
//   {
//     color: "red",
//     position: {
//       x: 0,
//       y: 0,
//     },
//   },
//   {
//     color: "green",
//     position: {
//       x: 1,
//       y: 0,
//     },
//   },
//   {
//     color: "blue",
//     position: {
//       x: 0,
//       y: 1,
//     },
//   },
// ];

export const addSquare = (newSquare: Square) => {
  return fetch(`${API_URL}/squares/add`, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(newSquare),
  }).then((res) => res.json());

  // return new Promise<Square[]>((resolve) => {
  //   _mockedSquares = [..._mockedSquares, newSquare];
  //   resolve(_mockedSquares);
  // });
};

export const getSquares = () => {
  return fetch(`${API_URL}/squares/get`).then((res) => res.json());

  // return new Promise<Square[]>((resolve) => {
  //   setTimeout(() => {
  //     resolve(_mockedSquares);
  //   }, 150);
  // });
};

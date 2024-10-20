import { Array2d } from "./array.utils";

export function drawSquare(
  context: CanvasRenderingContext2D,
  x: number,
  y: number,
  size: number,
  color: string
) {
  context.fillStyle = "#000";
  context.fillRect(x, y, size, size);

  context.fillStyle = color;
  context.fillRect(x + 1, y + 1, size - 2, size - 2);
}

export function drawSquares(
  canvas: HTMLCanvasElement,
  squares: Array2d,
  squaresSize: number,
  squaresMargin: number
) {
  const context = canvas.getContext("2d");
  const squaresPerRow = squares.length;

  const gridSize =
    squaresPerRow * squaresSize + (squaresPerRow - 1) * squaresMargin;

  const startX = (canvas.width - gridSize) / 2;
  const startY = (canvas.height - gridSize) / 2;

  context?.clearRect(0, 0, canvas.width, canvas.height);

  for (let row = 0; row < squaresPerRow; row++) {
    for (let col = 0; col < squaresPerRow; col++) {
      const color = squares[row][col];
      if (color !== null) {
        const x = startX + col * (squaresSize + squaresMargin);
        const y = startY + row * (squaresSize + squaresMargin);
        drawSquare(
          context as CanvasRenderingContext2D,
          x,
          y,
          squaresSize,
          color
        );
      }
    }
  }
}

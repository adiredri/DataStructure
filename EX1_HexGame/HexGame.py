"""
************  MATALA 1  ************
"""

class UnionFind:
    def __init__(self, size):
        self.parent = list(range(size))
        self.rank = [0] * size

    def find(self, x):
        # Path compression
        if self.parent[x] != x:
            self.parent[x] = self.find(self.parent[x])
        return self.parent[x]

    def union(self, x, y):
        # Union by rank
        px, py = self.find(x), self.find(y)
        if px == py:
            return
        if self.rank[px] < self.rank[py]:
            px, py = py, px
        self.parent[py] = px
        if self.rank[px] == self.rank[py]:
            self.rank[px] += 1


class HexGame:
    def __init__(self, n):
        self.n = n
        self.board = [[None for _ in range(n)] for _ in range(n)]
        # Virtual nodes for board edges
        self.white_uf = UnionFind(n * n + 2)
        self.black_uf = UnionFind(n * n + 2)
        self.WHITE_START = n * n
        self.WHITE_END = n * n + 1
        self.BLACK_START = n * n
        self.BLACK_END = n * n + 1

    def get_neighbors(self, row, col):
        # Get all valid neighboring cells
        directions = [(0, 1), (1, 0), (1, -1), (0, -1), (-1, 0), (-1, 1)]
        neighbors = []
        for dr, dc in directions:
            new_row, new_col = row + dr, col + dc
            if 0 <= new_row < self.n and 0 <= new_col < self.n:
                neighbors.append((new_row, new_col))
        return neighbors

    def make_move(self, row, col, color):
        # Check if move is valid
        if not (0 <= row < self.n and 0 <= col < self.n) or self.board[row][col] is not None:
            return False

        self.board[row][col] = color
        pos = row * self.n + col

        if color == 'W':
            uf = self.white_uf
            # Connect to virtual nodes for white (left-right connection)
            if col == 0:
                uf.union(pos, self.WHITE_START)
            if col == self.n - 1:
                uf.union(pos, self.WHITE_END)
        else:  # Black
            uf = self.black_uf
            # Connect to virtual nodes for black (top-bottom connection)
            if row == 0:
                uf.union(pos, self.BLACK_START)
            if row == self.n - 1:
                uf.union(pos, self.BLACK_END)

        # Connect with neighboring cells of same color
        for nrow, ncol in self.get_neighbors(row, col):
            if self.board[nrow][ncol] == color:
                npos = nrow * self.n + ncol
                uf.union(pos, npos)

        return True

    def check_winner(self, color):
        # Check if virtual start and end nodes are connected
        if color == 'W':
            return self.white_uf.find(self.WHITE_START) == self.white_uf.find(self.WHITE_END)
        else:
            return self.black_uf.find(self.BLACK_START) == self.black_uf.find(self.BLACK_END)

    def display_board(self):
        print("  " + " ".join(str(i) for i in range(self.n)))
        for i in range(self.n):
            print(i, end=" ")
            print(" " * i, end="")  # Indent for hexagonal display
            for j in range(self.n):
                cell = self.board[i][j] or '.'
                print(cell, end=" ")
            print()


def play_game():
    print("Welcome to Hex Game!")

    while True:
        try:
            n = int(input("Enter board size (n): "))
            if not (3 <= n <= 8):
                print("Board size must be between 3 and 8. Please try again.")
                continue
            break
        except ValueError:
            print("Board size must be between 3 and 8. Please try again.")

    game = HexGame(n)

    current_player = 'W'  # White starts
    while True:
        game.display_board()
        color_name = "White" if current_player == 'W' else "Black"
        print(f"Player {color_name}'s turn ({current_player})")

        try:
            row = int(input("Enter row: "))
            col = int(input("Enter column: "))

            if not game.make_move(row, col, current_player):
                print("Invalid move, try again")
                continue

            if game.check_winner(current_player):
                game.display_board()
                print(f"Player {color_name} wins!")
                break

            current_player = 'B' if current_player == 'W' else 'W'

        except ValueError:
            print("Invalid input, try again")


if __name__ == "__main__":
    play_game()

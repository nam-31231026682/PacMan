using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Towel;
using static Towel.Statics;

#region Ascii

// ╔═══════════════════╦═══════════════════╗
// ║ · · · · · · · · · ║ · · · · · · · · · ║
// ║ · ╔═╗ · ╔═════╗ · ║ · ╔═════╗ · ╔═╗ · ║
// ║ + ╚═╝ · ╚═════╝ · ╨ · ╚═════╝ · ╚═╝ + ║
// ║ · · · · · · · · · · · · · · · · · · · ║
// ║ · ═══ · ╥ · ══════╦══════ · ╥ · ═══ · ║
// ║ · · · · ║ · · · · ║ · · · · ║ · · · · ║
// ╚═════╗ · ╠══════   ╨   ══════╣ · ╔═════╝
//       ║ · ║                   ║ · ║
// ══════╝ · ╨   ╔════---════╗   ╨ · ╚══════
//         ·     ║ █ █   █ █ ║     ·        
// ══════╗ · ╥   ║           ║   ╥ · ╔══════
//       ║ · ║   ╚═══════════╝   ║ · ║
//       ║ · ║       READY       ║ · ║
// ╔═════╝ · ╨   ══════╦══════   ╨ · ╚═════╗
// ║ · · · · · · · · · ║ · · · · · · · · · ║
// ║ · ══╗ · ═══════ · ╨ · ═══════ · ╔══ · ║
// ║ + · ║ · · · · · · █ · · · · · · ║ · + ║
// ╠══ · ╨ · ╥ · ══════╦══════ · ╥ · ╨ · ══╣
// ║ · · · · ║ · · · · ║ · · · · ║ · · · · ║
// ║ · ══════╩══════ · ╨ · ══════╩══════ · ║
// ║ · · · · · · · · · · · · · · · · · · · ║
// ╚═══════════════════════════════════════╝

string WallsString =
	"╔═══════════════════╦═══════════════════╗\n" +
	"║                   ║                   ║\n" +
	"║   ╔═╗   ╔═════╗   ║   ╔═════╗   ╔═╗   ║\n" +
	"║   ╚═╝   ╚═════╝   ╨   ╚═════╝   ╚═╝   ║\n" +
	"║                                       ║\n" +
	"║   ═══   ╥   ══════╦══════   ╥   ═══   ║\n" +
	"║         ║         ║         ║         ║\n" +
	"╚═════╗   ╠══════   ╨   ══════╣   ╔═════╝\n" +
	"      ║   ║                   ║   ║      \n" +
	"══════╝   ╨   ╔════   ════╗   ╨   ╚══════\n" +
	"              ║           ║              \n" +
	"══════╗   ╥   ║           ║   ╥   ╔══════\n" +
	"      ║   ║   ╚═══════════╝   ║   ║      \n" +
	"      ║   ║                   ║   ║      \n" +
	"╔═════╝   ╨   ══════╦══════   ╨   ╚═════╗\n" +
	"║                   ║                   ║\n" +
	"║   ══╗   ═══════   ╨   ═══════   ╔══   ║\n" +
	"║     ║                           ║     ║\n" +
	"╠══   ╨   ╥   ══════╦══════   ╥   ╨   ══╣\n" +
	"║         ║         ║         ║         ║\n" +
	"║   ══════╩══════   ╨   ══════╩══════   ║\n" +
	"║                                       ║\n" +
	"╚═══════════════════════════════════════╝";

string GhostWallsString =
	"╔═══════════════════╦═══════════════════╗\n" +
	"║█                 █║█                 █║\n" +
	"║█ █╔═╗█ █╔═════╗█ █║█ █╔═════╗█ █╔═╗█ █║\n" +
	"║█ █╚═╝█ █╚═════╝█ █╨█ █╚═════╝█ █╚═╝█ █║\n" +
	"║█                                     █║\n" +
	"║█ █═══█ █╥█ █══════╦══════█ █╥█ █═══█ █║\n" +
	"║█       █║█       █║█       █║█       █║\n" +
	"╚═════╗█ █╠══════█ █╨█ █══════╣█ █╔═════╝\n" +
	"██████║█ █║█                 █║█ █║██████\n" +
	"══════╝█ █╨█ █╔════█ █════╗█ █╨█ █╚══════\n" +
	"             █║█         █║█             \n" +
	"══════╗█  ╥█ █║███████████║█ █╥█ █╔══════\n" +
	"██████║█  ║█ █╚═══════════╝█ █║█ █║██████\n" +
	"██████║█  ║█                 █║█ █║██████\n" +
	"╔═════╝█  ╨█ █══════╦══════█ █╨█ █╚═════╗\n" +
	"║█                 █║█                 █║\n" +
	"║█ █══╗█ █═══════█ █╨█ █═══════█ █╔══█ █║\n" +
	"║█   █║█                         █║█   █║\n" +
	"╠══█ █╨█ █╥█ █══════╦══════█ █╥█ █╨█ █══╣\n" +
	"║█       █║█       █║█       █║█       █║\n" +
	"║█ █══════╩══════█ █╨█ █══════╩══════█ █║\n" +
	"║█                                     █║\n" +
	"╚═══════════════════════════════════════╝";

string DotsString =
	"                                         \n" +
	"  · · · · · · · · ·   · · · · · · · · ·  \n" +
	"  ·     ·         ·   ·         ·     ·  \n" +
	"  +     ·         ·   ·         ·     +  \n" +
	"  · · · · · · · · · · · · · · · · · · ·  \n" +
	"  ·     ·   ·               ·   ·     ·  \n" +
	"  · · · ·   · · · ·   · · · ·   · · · ·  \n" +
	"        ·                       ·        \n" +
	"        ·                       ·        \n" +
	"        ·                       ·        \n" +
	"        ·                       ·        \n" +
	"        ·                       ·        \n" +
	"        ·                       ·        \n" +
	"        ·                       ·        \n" +
	"        ·                       ·        \n" +
	"  · · · · · · · · ·   · · · · · · · · ·  \n" +
	"  ·     ·         ·   ·         ·     ·  \n" +
	"  + ·   · · · · · ·   · · · · · ·   · +  \n" +
	"    ·   ·   ·               ·   ·   ·    \n" +
	"  · · · ·   · · · ·   · · · ·   · · · ·  \n" +
	"  ·               ·   ·               ·  \n" +
	"  · · · · · · · · · · · · · · · · · · ·  \n" +
	"                                         ";

string[] PacManAnimations =
[
	"\"' '\"",
	"n. .n",
	")>- ->",
	"(<- -<",
];

#endregion

int OriginalWindowWidth = Console.WindowWidth;
int OriginalWindowHeight = Console.WindowHeight;
ConsoleColor OriginalBackgroundColor = Console.BackgroundColor;
ConsoleColor OriginalForegroundColor = Console.ForegroundColor;

char[,] Dots; //2d array fro dots
int Score; //store point
(int X, int Y) PacManPosition; //tuple of int X, Y
Direction? PacManMovingDirection = default;
int? PacManMovingFrame = default;
const int FramesToMoveHorizontal = 6;
const int FramesToMoveVertical = 6;
Ghost[] Ghosts; //tạo mảng 
const int GhostWeakTime = 200;
(int X, int Y)[] Locations = GetLocations();

Console.Clear(); //xóa màn hình Console
try
{
	if (OperatingSystem.IsWindows()) 
	{
		Console.WindowWidth = 50;
		Console.WindowHeight = 30;
	}
	Console.CursorVisible = false;
	Console.BackgroundColor = ConsoleColor.Black;
	Console.ForegroundColor = ConsoleColor.White;
	Score = 0;
NextRound:
	Console.Clear();
	SetUpDots(); //Gọi hàm để tạo .
	PacManPosition = (20, 17);

	Ghost a = new();
	a.Position = a.StartPosition = (16, 10);
	a.Color = ConsoleColor.Red;
	a.FramesToUpdate = 6;
	a.Update = () => UpdateGhost(a);

	Ghost b = new();
	b.Position = b.StartPosition = (18, 10);
	b.Color = ConsoleColor.DarkGreen;
	b.Destination = GetRandomLocation();
	b.FramesToUpdate = 6;
	b.Update = () => UpdateGhost(b);

	Ghost c = new();
	c.Position = c.StartPosition = (22, 10);
	c.Color = ConsoleColor.Magenta;
	c.FramesToUpdate = 12;
	c.Update = () => UpdateGhost(c);

	Ghost d = new();
	d.Position = d.StartPosition = (24, 10);
	d.Color = ConsoleColor.DarkCyan;
	d.Destination = GetRandomLocation();
	d.FramesToUpdate = 12;
	d.Update = () => UpdateGhost(d);

	Ghosts = [a, b, c, d,];

	RenderWalls(); //vẽ tường
	RenderGate(); //vẽ cổng
    RenderDots();
	RenderReady(); //hiện màn hình ready
    RenderPacMan();
	RenderGhosts();
	RenderScore();
	if (GetStartingDirectionInput())
	{
		return; // user hit escape
	}
	PacManMovingFrame = 0;
	EraseReady();
	while (CountDots() > 0) //tiếp tục chạy khi . > 0
	{
		if (HandleInput())
		{
			return; // user hit escape
		}
		UpdatePacMan(); //cập nhật trạng thái 
		UpdateGhosts();
		RenderScore();
		RenderDots();
		RenderPacMan();
		RenderGhosts();
		foreach (Ghost ghost in Ghosts)
		{
			if (ghost.Position == PacManPosition)
			{
				if (ghost.Weak) //nếu Ghost đang Weak thì
				{
					ghost.Position = ghost.StartPosition;
					ghost.Weak = false;
					Score += 10;
				}
				else
				{
					Console.SetCursorPosition(0, 24);
					Console.WriteLine("Game Over!");
					Console.WriteLine("Play Again [enter], or quit [escape]?");
				GetInput:
					switch (Console.ReadKey(true).Key) //chọn giữa 2 input
					{
						case ConsoleKey.Enter: goto NextRound;
						case ConsoleKey.Escape: Console.Clear(); return;
						default: goto GetInput;
					}
				}
			}
		}
		Thread.Sleep(TimeSpan.FromMilliseconds(40)); //ngắt 40ms giữa các loop
	}
	goto NextRound;
}
finally //luôn execute bất kể ở trên trả lại gì
{
	Console.CursorVisible = true;
	if (OperatingSystem.IsWindows())
	{
		Console.WindowWidth = OriginalWindowWidth;
		Console.WindowHeight = OriginalWindowHeight;
	}
	Console.BackgroundColor = OriginalBackgroundColor;
	Console.ForegroundColor = OriginalForegroundColor;
}

	bool GetStartingDirectionInput()
	{
	GetInput: //chờ input từ người chơi rồi mới bắt đầu
		ConsoleKey key = Console.ReadKey(true).Key; //đọc user input và xử lí 
		switch (key) //xử lí
		{
			case ConsoleKey.LeftArrow: PacManMovingDirection = Direction.Left; break;
			case ConsoleKey.RightArrow: PacManMovingDirection = Direction.Right; break;
			case ConsoleKey.Escape: Console.Clear(); Console.Write("PacMan was closed."); return true;
			default: goto GetInput; //user input không hợp lệ thì quay lại chờ input khác
		}
		return false; //khi user ấn escape
	}

	bool HandleInput()  //trả về true nếu nhấn phím Escape.
						//Trả về false nếu không có phím yêu cầu thoát trò chơi nào được nhấn.
	{
		bool moved = false;
		void TrySetPacManDirection(Direction direction)
		{
			if (!moved && //PM chưa di chuyển
				PacManMovingDirection != direction && //hướng mới phải # hướng đang di chuyển
				CanMove(PacManPosition.X, PacManPosition.Y, direction)) //check đường đi có avai ko
			{
				PacManMovingDirection = direction; //update hướng di chuyển 
				PacManMovingFrame = 0; //reset khung hình
				moved = true;
			}
		}
		while (Console.KeyAvailable) //check input
		{
			switch (Console.ReadKey(true).Key) //read input và xử lí phím
			{
				case ConsoleKey.UpArrow: TrySetPacManDirection(Direction.Up); break;
				case ConsoleKey.DownArrow: TrySetPacManDirection(Direction.Down); break;
				case ConsoleKey.LeftArrow: TrySetPacManDirection(Direction.Left); break;
				case ConsoleKey.RightArrow: TrySetPacManDirection(Direction.Right); break;
				case ConsoleKey.Escape:
					Console.Clear();
					Console.Write("Ban da an Escape. Thoat tro choi!");
					Console.ReadKey();
					return true;
			}
		}
		return false;
	}

//x là cột, y là hàng
	char BoardAt(int x, int y) => WallsString[y * 42 + x];

	bool IsWall(int x, int y) => BoardAt(x, y) is not ' ';

	bool CanMove(int x, int y, Direction direction) => direction switch
	{
		Direction.Up => //check 3 ô phía trên 
			!IsWall(x - 1, y - 1) && //ô trên trái
			!IsWall(x, y - 1) &&  //ô trên giữa
            !IsWall(x + 1, y - 1), //ô trên phải
        Direction.Down =>
			!IsWall(x - 1, y + 1) && //ô dưới trái
			!IsWall(x, y + 1) && //ô dưới giữa
            !IsWall(x + 1, y + 1), //ô dưới phải
        Direction.Left =>
			x - 2 < 0 || !IsWall(x - 2, y), //0 là border trái của map
		Direction.Right =>
			x + 2 > 40 || !IsWall(x + 2, y), //40 là border phải của map
        _ => throw new NotImplementedException(),
	};

	void SetUpDots()
	{
		string[] rows = DotsString.Split("\n"); //chia DotsString thành các hàng
		int rowCount = rows.Length;
		int columnCount = rows[0].Length;
		Dots = new char[columnCount, rowCount]; //tạo ma trận Dots
		for (int row = 0; row < rowCount; row++)
		{
			for (int column = 0; column < columnCount; column++)
			{
				Dots[column, row] = rows[row][column];
			}
		}
	}

	int CountDots()
	{
		int count = 0;
		int columnCount = Dots.GetLength(0);
		int rowCount = Dots.GetLength(1);
		for (int row = 0; row < rowCount; row++)
		{
			for (int column = 0; column < columnCount; column++)
			{
				if (!char.IsWhiteSpace(Dots[column, row]))
				{
					count++;
				}
			}
		}
		return count;
	}

	void UpdatePacMan()
	{
		if (PacManMovingDirection.HasValue)
		{
			if ((PacManMovingDirection == Direction.Left || PacManMovingDirection == Direction.Right) && PacManMovingFrame >= FramesToMoveHorizontal ||
				(PacManMovingDirection == Direction.Up || PacManMovingDirection == Direction.Down) && PacManMovingFrame >= FramesToMoveVertical)
			{
				PacManMovingFrame = 1; //tốc độ của PM
				int x_adjust =
					PacManMovingDirection == Direction.Left ? -1 :
					PacManMovingDirection == Direction.Right ? 1 :
					0;
				int y_adjust =
					PacManMovingDirection == Direction.Up ? -1 :
					PacManMovingDirection == Direction.Down ? 1 :
					0;
				Console.SetCursorPosition(PacManPosition.X, PacManPosition.Y);
				Console.Write(" ");
				PacManPosition = (PacManPosition.X + x_adjust, PacManPosition.Y + y_adjust);
				if (PacManPosition.X < 0)
				{
					PacManPosition.X = 40;
				}
				else if (PacManPosition.X > 40)
				{
					PacManPosition.X = 0;
				}
				if (Dots[PacManPosition.X, PacManPosition.Y] is '·') //ăn . thì
				{
					Dots[PacManPosition.X, PacManPosition.Y] = ' ';
					Score += 1;
				}
				if (Dots[PacManPosition.X, PacManPosition.Y] is '+') //ăn + thì
				{
					foreach (Ghost ghost in Ghosts)
					{
						ghost.Weak = true;
						ghost.WeakTime = 0;
					}
					Dots[PacManPosition.X, PacManPosition.Y] = ' ';
					Score += 3;
				}
				if (!CanMove(PacManPosition.X, PacManPosition.Y, PacManMovingDirection.Value))
				{
					PacManMovingDirection = null;
				}
			}
			else
			{
				PacManMovingFrame++;
			}
		}
	}

	void RenderReady()
	{
		Console.SetCursorPosition(18, 13);
		WithColors(ConsoleColor.White, ConsoleColor.Black, () =>
		{
			Console.Write("READY");
		});
	}

	void EraseReady()
	{
		Console.SetCursorPosition(18, 13);
		Console.Write("     ");
	}

	void RenderScore()
	{
		Console.SetCursorPosition(0, 23);
		Console.Write("Score: " + Score);
	}

	void RenderGate()
	{
		Console.SetCursorPosition(19, 9);
		WithColors(ConsoleColor.Magenta, ConsoleColor.Black, () =>
		{
			Console.Write("---");
		});
	}

	void RenderWalls()
	{
		Console.SetCursorPosition(0, 0);
		WithColors(ConsoleColor.Blue, ConsoleColor.Black, () =>
		{
			Render(WallsString, false);
		});
	}

	void RenderDots()
	{
		Console.SetCursorPosition(0, 0);
		WithColors(ConsoleColor.DarkYellow, ConsoleColor.Black, () =>
		{
			for (int row = 0; row < Dots.GetLength(1); row++)
			{
				for (int column = 0; column < Dots.GetLength(0); column++)
				{
					if (!char.IsWhiteSpace(Dots[column, row]))
					{
						Console.SetCursorPosition(column, row);
						Console.Write(Dots[column, row]);
					}
				}
			}
		});
	}

	void RenderPacMan()
	{
		Console.SetCursorPosition(PacManPosition.X, PacManPosition.Y);
		WithColors(ConsoleColor.Black, ConsoleColor.Yellow, () =>
		{
			if (PacManMovingDirection.HasValue && PacManMovingFrame.HasValue)
			{
				int frame = (int)PacManMovingFrame % PacManAnimations[(int)PacManMovingDirection].Length;
				Console.Write(PacManAnimations[(int)PacManMovingDirection][frame]);
			}
			else
			{
				Console.Write(' ');
			}
		});
	}

	void RenderGhosts()
	{
		foreach (Ghost ghost in Ghosts)
		{
			Console.SetCursorPosition(ghost.Position.X, ghost.Position.Y);
			WithColors(ConsoleColor.White, ghost.Weak ? ConsoleColor.Blue : ghost.Color, () => Console.Write('"'));
		}
	}

	void WithColors(ConsoleColor foreground, ConsoleColor background, Action action)
	{
		ConsoleColor originalForeground = Console.ForegroundColor;
		ConsoleColor originalBackground = Console.BackgroundColor;
		try
		{
			Console.ForegroundColor = foreground;
			Console.BackgroundColor = background;
			action();
		}
		finally
		{
			Console.ForegroundColor = originalForeground;
			Console.BackgroundColor = originalBackground;
		}
	}

	void Render(string @string, bool renderSpace = true)
	{
		int x = Console.CursorLeft;
		int y = Console.CursorTop;
		foreach (char c in @string)
		{
			if (c is '\n')
			{
				Console.SetCursorPosition(x, ++y);
			}
			else if (c is not ' ' || renderSpace)
			{
				Console.Write(c);
			}
			else
			{
				Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
			}
		}
	}

	void UpdateGhosts()
	{
		foreach (Ghost ghost in Ghosts)
		{
			ghost.Update!();
		}
	}

	void UpdateGhost(Ghost ghost)
	{
		if (ghost.Destination.HasValue && ghost.Destination == ghost.Position)
		{
			ghost.Destination = GetRandomLocation();
		}
		if (ghost.Weak)
		{
			ghost.WeakTime++;
			if (ghost.WeakTime > GhostWeakTime)
			{
				ghost.Weak = false;
			}
		}
		else if (ghost.UpdateFrame < ghost.FramesToUpdate)
		{
			ghost.UpdateFrame++;
		}
		else
		{
			Console.SetCursorPosition(ghost.Position.X, ghost.Position.Y);
			Console.Write(' ');
			ghost.Position = GetGhostNextMove(ghost.Position, ghost.Destination ?? PacManPosition);
			ghost.UpdateFrame = 0;
		}
	}

	

	(int X, int Y)[] GetLocations()
	{
		List<(int X, int Y)> list = new();
		int x = 0;
		int y = 0;
		foreach (char c in GhostWallsString)
		{
			if (c is '\n')
			{
				x = 0;
				y++;
			}
			else
			{
				if (c is ' ')
				{
					list.Add((x, y));
				}
				x++;
			}
		}
		return [.. list];
	}

	(int X, int Y) GetRandomLocation() => Random.Shared.Choose(Locations);

	(int X, int Y) GetGhostNextMove((int X, int Y) position, (int X, int Y) destination)
	{
		HashSet<(int X, int Y)> alreadyUsed = new();

		char BoardAt(int x, int y) => GhostWallsString[y * 42 + x];

		bool IsWall(int x, int y) => BoardAt(x, y) is not ' ';

		void Neighbors((int X, int Y) currentLocation, Action<(int X, int Y)> neighbors)
		{
			void HandleNeighbor(int x, int y)
			{
				if (!alreadyUsed.Contains((x, y)) && x >= 0 && x <= 40 && !IsWall(x, y))
				{
					alreadyUsed.Add((x, y));
					neighbors((x, y));
				}
			}

			int x = currentLocation.X;
			int y = currentLocation.Y;
			HandleNeighbor(x - 1, y); // left
			HandleNeighbor(x, y + 1); // up
			HandleNeighbor(x + 1, y); // right
			HandleNeighbor(x, y - 1); // down
		}

		int Heuristic((int X, int Y) node)
		{
			int x = node.X - PacManPosition.X;
			int y = node.Y - PacManPosition.Y;
			return x * x + y * y;
		}

		Action<Action<(int X, int Y)>> path = SearchGraph(position, Neighbors, Heuristic, node => node == destination)!;
		(int X, int Y)[] array = path.ToArray();
		return array[1];
	}

class Ghost
{
	public (int X, int Y) StartPosition;
	public (int X, int Y) Position;
	public bool Weak;   //bool indicates when the ghost is in a weak state
    public int WeakTime; //counting down the time ghost remain weak
	public ConsoleColor Color;   //color of ghost
	public Action? Update;  //updating the ghost state and location
	public int UpdateFrame;
	public int FramesToUpdate; //control the ghost's speed
	public (int X, int Y)? Destination;
}

enum Direction
{ //determine how how PacMan update its position based on user's input
    Up = 0,
	Down = 1,
	Left = 2,
	Right = 3,
}

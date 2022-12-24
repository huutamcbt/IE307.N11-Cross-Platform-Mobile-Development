// snack game using class
#include <iostream>
#include <conio.h>
#include <windows.h>
using namespace std;
class snack
{
private:
    int x, y, fruitx, fruity, score;
    int tailx[100], taily[100];
    int ntail;
    enum eDirection
    {
        STOP = 0,
        LEFT,
        RIGHT,
        UP,
        DOWN
    };
    eDirection dir;

public:
    snack();
    void setup();
    void draw();
    void input();
    void logic();
    bool gameover();
};
snack::snack()
{
    x = 20;
    y = 20;
    fruitx = 10;
    fruity = 10;
    score = 0;
    ntail = 0;
    dir = STOP;
}
void snack::setup()
{
    system("cls");
    draw();
    input();
    logic();
}
void snack::draw()
{
    system("cls");
    for (int i = 0; i < 20; i++)
    {
        for (int j = 0; j < 40; j++)
        {
            if (i == 0 || i == 19)
            {
                cout << "#";
            }
            else if (j == 0 || j == 39)
            {
                cout << "#";
            }
            else if (i == y && j == x)
            {
                cout << "O";
            }
            else if (i == fruity && j == fruitx)
            {
                cout << "F";
            }
            else
            {
                bool print = false;
                for (int k = 0; k < ntail; k++)
                {
                    if (tailx[k] == j && taily[k] == i)
                    {
                        cout << "o";
                        print = true;
                    }
                }
                if (!print)
                {
                    cout << " ";
                }
            }
        }
        cout << endl;
    }
    cout << "score:" << score << endl;
}
void snack::input()
{
    if (_kbhit())
    {
        switch (_getch())
        {
        case 'a':
            dir = LEFT;
            break;
        case 'd':
            dir = RIGHT;
            break;
        case 'w':
            dir = UP;
            break;
        case 's':
            dir = DOWN;
            break;
        case 'x':
            dir = STOP;
            break;
        }
    }
}
void snack::logic()
{
    int prevx = tailx[0];
    int prevy = taily[0];
    int prev2x, prev2y;
    tailx[0] = x;
    taily[0] = y;
    for (int i = 1; i < ntail; i++)
    {
        prev2x = tailx[i];
        prev2y = taily[i];
        tailx[i] = prevx;
        taily[i] = prevy;
        prevx = prev2x;
        prevy = prev2y;
    }
    switch (dir)
    {
    case LEFT:
        x--;
        break;
    case RIGHT:
        x++;
        break;
    case UP:
        y--;
        break;
    case DOWN:
        y++;
        break;
    case STOP:
        break;
    }
    if (x > 38 || x < 1 || y > 18 || y < 1)
    {
        gameover();
    }
    for (int i = 0; i < ntail; i++)
    {
        if (tailx[i] == x && taily[i] == y)
        {
            gameover();
        }
    }
    if (x == fruitx && y == fruity)
    {
        score += 10;
        fruitx = rand() % 38;
        fruity = rand() % 18;
        ntail++;
    }
}
bool snack::gameover()
{
    cout << "game over" << endl;
    cout << "score:" << score << endl;
    return true;
}
int main()
{
    snack s;
    while (!s.gameover())
    {
        s.setup();
        Sleep(100);
    }
    return 0;
}

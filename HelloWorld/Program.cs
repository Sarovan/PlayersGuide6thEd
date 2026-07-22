Countdown(10);

void Countdown(int num)
{
    if (num == 0) return;
    Console.WriteLine(num);
    Countdown(num - 1);
}
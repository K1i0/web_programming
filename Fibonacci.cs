
class Fibonacci
{
    // static void Main(string[] args)
    // {
    //     Console.Write("Input months count: ");
    //     int monthsCount = Convert.ToInt32(Console.ReadLine());
    //     Console.Write($"Rabbits pair count after {monthsCount} months: {calcFibonacci(monthsCount)}");
    // }
    public static int calcFibonacci(int n)
    {
        if (n == 1 || n == 2) {
            return n;
        }
        return calcFibonacci(n - 1) + calcFibonacci(n - 2);
    }
}

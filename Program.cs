using System;
using System.Numerics;
using System.Text;

class Program
{
    static void Main(string[]args)
    {
        int[,] matrix = new int[52,2];
        int j = 0;
        for(int i=65;i<=122;i++)
        {
            if(i<=90 || i>=97)
            {
                matrix[j, 0] = matrix[j, 1] = i;
                j++;
            }
        }
        Shuffle(matrix);
        Console.WriteLine("Enter Text:");
        string text = Console.ReadLine();
        Console.WriteLine("a.Encrypt");
        Console.WriteLine("b.Decrypt");
        Console.WriteLine("Select an option from a or b");
        string aux = Console.ReadLine();
        string option = aux.ToLower();
        switch (option)
        {
            case "a":
                Console.WriteLine($"Encrypted:{Encrypt(text,matrix)}");
                break;
            case "b":
                Console.WriteLine($"Decrypted:{Decrypt(text,matrix)}");
                break;
            default:
                Console.WriteLine("You need to select an option from a or b");
                break;
        }
    }
    static string Encrypt(string a,int[,]matrix)
    {
        for (int i = 0; i < a.Length; i++)
        {
            char var = ' ';
            int aux = (int)a[i];
            if (65 <= aux && aux <= 90 || 97 <= aux && aux <= 122)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (aux == matrix[j, 0])
                    {
                        var = (char)matrix[j, 1];
                        break;
                    }
                }
            }
            if (var != ' ')
            {
                StringBuilder s = new StringBuilder(a);
                s[i] = var;
                a = s.ToString();
            }
        }
        return a;
    }
    static string Decrypt(string a, int[,]matrix)
    {
        for (int i = 0; i < a.Length; i++)
        {
            char var = ' ';
            int aux = (int)a[i];
            if (65 <= aux && aux <= 90 || 97 <= aux && aux <= 122)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (aux == matrix[j, 1])
                    {
                        var = (char)matrix[j, 0];
                        break;
                    }
                }
            }
            if (var != ' ')
            {
                StringBuilder s = new StringBuilder(a);
                s[i] = var;
                a = s.ToString();
            }
        }
        return a;
    }
    static void Shuffle(int[,]matrix)
    {
        Random random = new Random();
        int n = matrix.GetLength(0);
        for(int i=0;i<n;i++)
        {
            int r = i + random.Next(n - i);
            if ((65 <= matrix[r,0] && 65 <= matrix[i, 0]) && (matrix[r,0]<=90 && matrix[i,0]<=90)|| (97 <= matrix[r, 0] && 97 <= matrix[i, 0]) && (matrix[r, 0] <= 122 && matrix[i, 0] <= 122))
            {
                int aux=matrix[r,0];
                matrix[r,0]=matrix[i,0];
                matrix[i,0]=aux;
            }
        }
    }
}

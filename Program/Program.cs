Console.Write("Introduceti numarul in virgula fixa (ex. 10.625): ");
        string numarInput = Console.ReadLine();

        Console.Write("Introduceti baza initiala (intre 2 si 16): ");
        int bazaInitiala = int.Parse(Console.ReadLine());

        Console.Write("Introduceti baza finala (intre 2 si 16): ");
        int bazaFinala = int.Parse(Console.ReadLine());

        if (bazaInitiala < 2 || bazaInitiala > 16 || bazaFinala < 2 || bazaFinala > 16)
        {
            Console.WriteLine("Bazele trebuie sa fie intre 2 si 16.");
            return;
        }

        string rezultat = ConversieBazaLaBaza(numarInput, bazaInitiala, bazaFinala);
        Console.WriteLine($"Rezultatul conversiei: {rezultat}");

static string ConversieBazaLaBaza(string numar, int bazaInitiala, int bazaFinala)
    {
        string[] parti = numar.Split('.');
        string parteIntreaga = ConversieBaza10LaBaza(parti[0], bazaInitiala, bazaFinala);
        string parteZecimala = ConversieParteZecimalaLaBazaN(parti.Length > 1 ? parti[1] : "0", bazaInitiala, bazaFinala);

        string rezultat = parteIntreaga + (parteZecimala != "" ? "." + parteZecimala : "");
        return rezultat;
    }

    static string ConversieBaza10LaBaza(string numar, int bazaInitiala, int bazaFinala)
    {
        int numarDecimal = Convert.ToInt32(numar, bazaInitiala);
        return ConversieBaza10LaBazaN(numarDecimal, bazaFinala);
    }

    static string ConversieBaza10LaBazaN(int numar, int baza)
    {
        if (numar == 0)
        {
            return "0";
        }

        string rezultat = "";
        while (numar > 0)
        {
            int rest = numar % baza;
            rezultat = RestLaCaracter(rest) + rezultat;
            numar /= baza;
        }

        return rezultat;
    }

    static string ConversieParteZecimalaLaBazaN(string parteZecimala, int bazaInitiala, int bazaFinala)
    {
        double parteZecimalaDecimal = 0;
        for (int i = 0; i < parteZecimala.Length; i++)
        {
            parteZecimalaDecimal += CharLaInt(parteZecimala[i]) * Math.Pow(bazaInitiala, -(i + 1));
        }

        string rezultat = "";
        for (int i = 0; i < 8; i++) // Numarul de cifre zecimale dupa virgula in rezultat.
        {
            parteZecimalaDecimal *= bazaFinala;
            int parteIntreagaZecimala = (int)parteZecimalaDecimal;
            rezultat += RestLaCaracter(parteIntreagaZecimala);
            parteZecimalaDecimal -= parteIntreagaZecimala;
        }

        return rezultat;
    }

    static char RestLaCaracter(int rest)
    {
        if (rest < 10)
        {
            return (char)('0' + rest);
        }
        else
        {
            return (char)('A' + rest - 10);
        }
    }

    static int CharLaInt(char cifra)
    {
        if (char.IsDigit(cifra))
        {
            return cifra - '0';
        }
        else
        {
            return char.ToUpper(cifra) - 'A' + 10;
        }
    }
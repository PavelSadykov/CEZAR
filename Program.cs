using System;

namespace Class_String_Ex;

//Создаем класс CaesarCipherExtensions для объявления методов расширения,
//которые позволят расширить функциональность класса string для работы с шифром Цезаря.
public static class CaesarCipherExtensions
{

    //Объявляем статический метод расширения Encrypt,
    //который принимает строку (this string str) в качестве первого параметра и
    //целочисленное значение shift в качестве второго параметра.
    //this перед первым параметром указывает на то, что данный метод расширяет тип string.
    //Это означает, что мы можем вызывать метод Encrypt прямо на объектах типа string
    //без явного указания на класс CaesarCipherExtensions.
    //После объявления метода Encrypt как метода расширения, его можно вызывать непосредственно
    //на объектах типа string, подобно встроенным методам класса string.
    public static string Encrypt(this string str, int shift)
    {
        string encrypted = "";//Создаем пустую строка, которая будет содержать зашифрованную строку.
        foreach (char c in str)// Цикл foreach проходит по каждому символу 'c' в исходной строке str.
        {
            if (Char.IsLetter(c) && Char.IsUpper(c))//проверяем,является ли символ 'c' буквой и заглавной латинской буквой
                                                    // с помощью методов Char.IsLetter и Char.IsUpper.
            {
                char encryptedChar = (char)(((c - 'A' + shift) % 26) + 'A');//шифрование:
                                                                            //c - 'A' вычисляет позицию символа в алфавите (от 0 до 25),
                                                                            //+ shift применяет сдвиг к позиции,
                                                                            //% 26 гарантирует, что результат остается в пределах 26 букв алфавита,
                                                                            // + 'A' преобразует позицию обратно в символ заглавной латинской буквы.
                encrypted += encryptedChar;//Зашифрованный символ добавляется к
                                           //зашифрованной строке encrypted.
            }
            else
            {
                encrypted += c; //Если символ не является буквой или не является заглавной
                                //латинской буквой, то он остается неизменным.
            }
        }
        return encrypted;//возвращвем зашифрованную  строку 

    }

    public static string Decrypt(this string str, int shift)
    {
        string decrypted = "";
        foreach (char c in str)
        {
            if (Char.IsLetter(c) && Char.IsUpper(c))
            {
                char decryptedChar = (char)(((c - 'A' - shift + 26) % 26) + 'A');// расшифровка:из 'c' вычитаем код первой заглавной латинской буквы 'A'.
                                                                                 // Затем из результата вычитаем значение shift.
                                                                                 // К результату добавляем 26(количество букв в алфавите)
                                                                                 // и берем по модулю 26, чтобы обеспечить цикличность расшифровки.
                                                                                 // К результату добавляется код  буквы 'A' для получения расшифрованного символа.
                decrypted += decryptedChar;
            }
            else
            {
                decrypted += c;
            }
        }
        return decrypted;
    }
}
class Program
{
    static void Main(string[] args)
    {

        string original = "HELLO WORLD";
        int shift = 3;

        string encrypted = original.Encrypt(shift);
        string decrypted = encrypted.Decrypt(shift);

        Console.WriteLine("Original: " + original);       // Вывод: Original: HELLO WORLD
        Console.WriteLine("Encrypted: " + encrypted);     // Вывод: Encrypted: KHOOR ZRUOG
        Console.WriteLine("Decrypted: " + decrypted);     // Вывод: Decrypted: HELLO WORLD
    }
}
using System;

namespace Caderneta_de_Alunos
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[50];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a primeira nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota1))
                        {
                            aluno.Nota1 = nota1;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }
                        Console.WriteLine("Informe a segunda nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota2))
                        {
                            aluno.Nota2 = nota2;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }
                        Console.WriteLine("Informe a terceira nota do aluno:");
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota3))
                        {
                            aluno.Nota3 = nota3;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }

                        var mediaAluno =  (aluno.Nota1 + aluno.Nota2 + aluno.Nota3) / 3;                     

                        aluno.Media = mediaAluno;
                                
                        
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTAS: {a.Nota1};{a.Nota2};{a.Nota3} - MÉDIA: {a.Media}");

                            }
                        }
                        break;
                    case "3":
                        
                        decimal mediaTotal = 0;
                        var nrAlunos = 0;

                        for(int i=0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                mediaTotal = mediaTotal + alunos[i].Media;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = mediaTotal / nrAlunos;
                        ConceitoEnum conceitoGeral;

                        if(mediaGeral < 2)
                        {
                            conceitoGeral = ConceitoEnum.E;
                        }
                        else if(mediaGeral < 4)
                        {
                            conceitoGeral = ConceitoEnum.D;
                        }
                        else if(mediaGeral < 6)
                        {
                            conceitoGeral = ConceitoEnum.C;
                        }
                        else if(mediaGeral < 8)
                        {
                            conceitoGeral = ConceitoEnum.B;
                        }
                        else
                        {
                            conceitoGeral = ConceitoEnum.A;
                        }
                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Insira a opção desejada");
            Console.WriteLine("1 - Insira o nome do aluno e as suas respectivas notas");
            Console.WriteLine("2 - Listar alunos com suas notas e médias");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}

using Apresentação;
class Program
{
    static void Main()
    {
        int escolha = 0;

        do
        {        
            Console.WriteLine("(1) Conversão de Tipos");
            Console.WriteLine("(2) Boxing e Unboxing ");
            Console.WriteLine("(3) UpCast e DowCast");
            Console.WriteLine("(4) Linq");
            Console.WriteLine("(5) Generic");
            Console.WriteLine("(0) Sair");

            escolha = Convert.ToInt32(Console.ReadLine());
            if (escolha == 1) { ConversaoTipos(); }
            if (escolha == 2) { BoxingUnboxing(); }
            if (escolha == 3) { UpcastDowcast(); }
            if (escolha == 4) { Linq(); }
            if (escolha == 5) { TestGenerico(); }

        } while (escolha != 0);

        void ConversaoTipos()
            {
                int Inteiro = 100;
                double Flutuante;
                string Palavra;

                Console.WriteLine("Conversão implicita");
                Flutuante = Inteiro;
                Console.WriteLine(Flutuante);
                Flutuante = 94.6;
                Console.WriteLine("Conversão explicita");
                Inteiro = (int)Flutuante;
                Console.WriteLine(Inteiro);

                Console.WriteLine("Conversão Convert");
                Inteiro = Convert.ToInt32(Flutuante);
                Console.WriteLine(Inteiro);

                Console.WriteLine("Conversão Convert Inteiro Para String");
                Inteiro = 50;
                Palavra = "nome";
                Console.WriteLine(Palavra);
                Palavra = Convert.ToString(Inteiro);
                Console.WriteLine(Palavra);
                
                Console.WriteLine("\n");

                string[] valor ={"+13230","-0",
                          "0xFA1B","","2147483647",
                          "2147483648",
                          "-2147483648","-2147483649"};
                foreach (string val in valor)
                {
                    try
                    {
                        int num = Convert.ToInt32(val);
                        Console.WriteLine("string: {0} || Inteiro: {1}", val, num);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("string: {0}: Formato Invalido", val);
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("string: {0}: Tamanho n Suportado", val);
                    }
                }
                Console.WriteLine("\n");

                Console.WriteLine("To Parse");
                foreach (string val in valor)
                {
                    try
                    {
                        int numero = Int32.Parse(val);
                        Console.WriteLine("string: {0} || Inteiro: {1}", val, numero);
                    }
               
                catch (FormatException)
                    {
                        Console.WriteLine("string: {0}: Formato Invalido", val);
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("string:{0}: Tamanho n Suportado", val);
                    }
                }
                Console.WriteLine("\n");
            }
       
        void BoxingUnboxing()
        {
            Console.WriteLine("Boxing");

            int Numero1 = 10;
            int Numero2 = 30;
            int Numero3 = 1000;
            string nome1 = "pedro";
            string nome2 = "Joao";
            object objeto = Numero1;
            Numero1 = 11;

            List<object> objetos = new List<object>();

            objetos.Add(Numero1);
            objetos.Add(Numero2);
            objetos.Add(Numero3);
            objetos.Add(nome1);
            objetos.Add(nome2);

            var NumersInteiros = objetos.OfType<int>().ToList();
            int numero4 = 5555;
            NumersInteiros.Add(numero4);
            foreach (int numero in NumersInteiros)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine("\n");
        }
        
        void UpcastDowcast()
        {
            
            PessoaFisica pessoaFisica = new PessoaFisica("diogo",28);
            Pessoa pessoa = new Pessoa("pedro");
            pessoa = pessoaFisica;//Upcast
            
            pessoaFisica = (PessoaFisica)pessoa;//Dowcast

            Console.WriteLine("Usando operador (as)");
            Pessoa pessoa1 = new Pessoa("pedro1");
            PessoaFisica pessoaFisica1 = pessoa1 as PessoaFisica;

            if (pessoaFisica1 == null)
            {
                Console.WriteLine("Operação de downcast inválida \n");
            }
            else
            {
                Console.WriteLine("Operação de downcast Realizadam com sucesso \n");
            }

            Pessoa pessoa2 = new Pessoa("pedro2");
            PessoaFisica pessoaFisica2 = new PessoaFisica("diogo2",28);
            pessoa2 = pessoaFisica2; // upcast
            Console.WriteLine("Usando operador (is)");
            if (pessoa2 is PessoaFisica pessoaFisicaF)
            {
                pessoaFisicaF.Cpf = 000111222;
                Console.WriteLine("Operação de downcast Realizadam com sucesso \n");
                Console.WriteLine("{0} {1}",pessoaFisicaF.Nome,pessoaFisicaF.Cpf);
            }
            else
            {
                Console.WriteLine("Operação de downcast inválida");
            }
        }
        
        void Linq() 
        {
            PessoaFisica pessoaFisica = new PessoaFisica("Joao",18);
            PessoaFisica pessoaFisica1 = new PessoaFisica("Maria", 38);
            PessoaFisica pessoaFisica2 = new PessoaFisica("Aline", 9);
            PessoaFisica pessoaFisica3 = new PessoaFisica("caio", 35);
            PessoaFisica pessoaFisica4 = new PessoaFisica("felipe", 55);
            PessoaFisica pessoaFisica5 = new PessoaFisica("Diogo", 21);

            List<PessoaFisica> pessoas = new List<PessoaFisica>();
            pessoas.Add(pessoaFisica);
            pessoas.Add(pessoaFisica1);
            pessoas.Add(pessoaFisica2);
            pessoas.Add(pessoaFisica3);
            pessoas.Add(pessoaFisica4);
            pessoas.Add(pessoaFisica5);

            int quantidadeLista = pessoas.Count;
            float mediaIdade = pessoas.Sum(pessoa => pessoa.Cpf)/quantidadeLista;
            int maiorIdade = pessoas.Max(pessoa => pessoa.Cpf);
            int menorIdade = pessoas.Min(pessoa => pessoa.Cpf);

            Console.WriteLine("A Media de idade das pessoas da lista e : {0}", mediaIdade);
            Console.WriteLine("A Maior idade de idade da lista e : {0}", maiorIdade);
            Console.WriteLine("A Menor de idade  da lista e : {0}", menorIdade);
            Console.WriteLine("\n ");
            IEnumerable <PessoaFisica> ConsultaPessoa = from pessoa in pessoas
                                                       where pessoa.Nome == "felipe"
                                                       select pessoa;
            if (!ConsultaPessoa.Any())
            {
                Console.WriteLine("consulta invalida ");
            }
            else
            {
                foreach (Pessoa resultado in ConsultaPessoa)
                {
                    Console.WriteLine("Pessoa com nome de 'felipe'");
                    Console.WriteLine(resultado.ToString());
                }
                Console.WriteLine("\n ");
            }
            IEnumerable<PessoaFisica> ConsultaPessoa2 = from pessoa in pessoas
                                                       where pessoa.Cpf > 18
                                                       select pessoa;
            if (!ConsultaPessoa2.Any())
            {
                Console.WriteLine("consulta invalida ");
            }
            else
            {
                Console.WriteLine("Pessoas com Idade maior de 18 anos");
                foreach (Pessoa resultado in ConsultaPessoa2)
                {                   
                    Console.WriteLine(resultado.ToString());
                }
                Console.WriteLine("\n ");
            }
        }
        
        void TestGenerico()
        {
            PessoaGenerica pessoaGenerica = new PessoaGenerica();
            pessoaGenerica.FuncaoGenerica(18, "nome");
            pessoaGenerica.FuncaoGenerica(28, 10);
            pessoaGenerica.FuncaoGenerica(10, true);
            pessoaGenerica.FuncaoGenerica(55, 'F');
            pessoaGenerica.FuncaoGenerica(44, 1000.22);
        }
    }
}
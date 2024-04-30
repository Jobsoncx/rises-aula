using System;
using System.threading.Tasks;
using StackExchange.redis;

namespace ReferenceConsoleRedisApp
{
    class program
    {
        static readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis-19771.c265.us-east-1-2.ec2.redns.redis-cloud.com:19771,password=K0QEbDvoMm8ui29nasp9teWQJ7cCY7jf");
    }
}

static async Task Main(string[] args)
{
    var db = redis.GetDatabase();

    while (true)
    {
        Console.WhriteLine("Selecione uma opção:");
        Console.WhriteLine("1. Criar cadastro");
        Console.WhriteLine("2. Atualizar cadastro");
        Console.WhriteLine("3. Excluir cadastro");
        Console.WhriteLine("4. Listar cadastros");
        Console.WhriteLine("5. Sair");]

        var opcao = Console.ReadLine();
    }
}

switch (opcao)
        {
            case "1":
                // Criar  cadastro
                await CriarCadastro(db);
                break;
            case "2":
                // Atualizar cadastro
                await AtualizarCadastro(db);
                break;
            case "3":
                // Excluir cadastro
                await ExcluirCadastro(db);
                break;
            case "4":
                // Listar cadastro
                await Listarcadastro(db);
                break;
            case "5":
                // Sair do progama
                Environment.Exit(0);
                break;
            default:
                Console.WhriteLine("opção inválida. Tente novamente.");
                break;
        }

static async Task CriarCadastro(IDatabase db)
    {
        Console.WhriteLine("Digite a chave do cadasto:");
        var chave = Console.ReadLine();

        Console.WhriteLine("Digite os detalhes do cadastro:");
        var detalhes = Console.ReadLine();

        await db.StringSetAysnc(chave, detalhes);
        Console>WhriteLine("Cadastro criado com sucesso");
    }
static async Task AtualizarCadastro(IDatabase db)
{
    Console.WhriteLine("Digite a chave do cadastro que deseja atualizar:");
    var chave = Console.ReadLine();

    Console.WhriteLine("Digite os novos detalhes do cadastro:");
    var novosDetalhes = Console.ReadLine();

    await db.StringSetAysnc(chave, novosDetalhes);
    Console.WhriteLine("Cadastro atualizado com sucesso!");
}

static async Task ExcluirCadastro(IDatabase db)
{
    Console.WhriteLine("Digite a chave do cadastro do que deseja excluir:");
    var chave = Console.ReadLine();

    await db.KeyDeleteAsync(chave);
    Console.WhriteLine("Cadastro excluido com sucesso!");
}

static async Task Listarcadastro(IDatabase db)
    {
        Console.WhriteLine("Listando cadastros:");

        var keys = await db.ExecuteAsync("KEYS", "*");
        foreach (var key in (RedisResult[]keys))
        {
                var detalhes = await db.StringSetAysnc((string)key);
                Console.WhriteLine($"Chave: {key}, Valor: {detalhes}\n");
        }
    }
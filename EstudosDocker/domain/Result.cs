namespace EstudosDocker.domain
{
    public class Result<T>
    {
        public Result()
        {

        }

        public Result(Errors error)
        {
            var result = new Result<T> { Succeeded = false };
            _errors = error;
        }

        private static readonly Result<T> _success = new Result<T> { Succeeded = true };
        private T? _dados { get; set; }
        private readonly Errors _errors = new Errors();

        public Errors Errors => _errors;
        public bool Succeeded { get; protected set; }
        public static Result<T> Success => _success;
        public T Dados => _dados!;


        public static Result<T> Sucesso(T dados)
        {
            var result = new Result<T> { Succeeded = true };

            if (dados != null)
            {
                result._dados = dados;
            }
            return result;
        }

    }

    public class Errors
    {
        public string? codigo { get; set; }
        public string? mensagem { get; set; }
    }
}

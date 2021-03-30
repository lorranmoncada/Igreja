namespace Igreja.Domain.ViewModel
{
    public class CadastroProprietarioViewModel
    {
        // cadastro
        public string Login { get; set; }
        public string Senha { get; set; }
        //Proprietario
        public string NomeProprietario { get; set; }
        public string CpfProrpietario { get; set; }
        //categoria
        public TipoCategoriaEnum TipoCategoria { get; set; }
        //igreja
        public string NomeEnderecoIgreja { get; set; }
        public string CepIgreja { get; set; }
        public string NomeIgreja { get; set; }
        public string CnpjIgreja { get; set; }
    }
}

namespace Cineminha.Dominio.Entidades
{
    public class Filme
    {
        public int IdFilme { get; set; }
        public byte[] Imagem { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Duracao { get; set; }
        public virtual ICollection<Sessao> Sessoes { get; set; } = new List<Sessao>();
    }
}
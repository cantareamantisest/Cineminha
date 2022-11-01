namespace Cineminha.Dominio.Entidades
{
    public class Sala
    {
        public int IdSala { get; set; }
        public string Nome { get; set; }
        public int Assentos { get; set; }
        public virtual ICollection<Sessao> Sessoes { get; set; } = new List<Sessao>();
    }
}
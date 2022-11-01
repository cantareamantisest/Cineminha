namespace Cineminha.Dominio.Entidades
{
    public class Sessao
    {
        public int IdSessao { get; set; }
        public int IdFilme { get; set; }
        public int IdSala { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public decimal ValorIngresso { get; set; }
        public int TipoAnimacao { get; set; }
        public int TipoAudio { get; set; }
        public virtual Filme Filme { get; set; }
        public virtual Sala Sala { get; set; }
    }
}
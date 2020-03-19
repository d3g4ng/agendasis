namespace AgendaSis.Domain.Entidades
{
    public class BaseEntity
    {
        public int Id { get; protected set; }

        public void SetaId(int id)
        {
            Id = id;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Common.Abstractions;

namespace Project.Domain.Models.Books;

public sealed class Book : BaseEntity
{
    private Book()
    {
        
    }

    public Book(string title,
        string description,
        string author)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Author = author ?? throw new ArgumentNullException(nameof(author));
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Author { get; private set; }

    public void Update(string title,
        string description,
        string author)
    {
        if (!string.IsNullOrEmpty(title))
            Title = title;

        if (!string.IsNullOrEmpty(description))
            Description = description;

        if (!string.IsNullOrEmpty(author))
            Author = author;
    }
}

public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);
        builder.ToTable("Books");
    
        builder.HasData(new List<Book>()
        {
            new("One Hundred Years of Solitude",
                "This novel is a multi-generational saga that focuses on the Buendía family, who founded the fictional town of Macondo. It explores themes of love, loss, family, and the cyclical nature of history. The story is filled with magical realism, blending the supernatural with the ordinary, as it chronicles the family's experiences, including civil war, marriages, births, and deaths. The book is renowned for its narrative style and its exploration of solitude, fate, and the inevitability of repetition in history.",
                "Gabriel García Márquez"),
            
            new("The Great Gatsby",
                "Set in the summer of 1922, the novel follows the life of a young and mysterious millionaire, his extravagant lifestyle in Long Island, and his obsessive love for a beautiful former debutante. As the story unfolds, the millionaire's dark secrets and the corrupt reality of the American dream during the Jazz Age are revealed. The narrative is a critique of the hedonistic excess and moral decay of the era, ultimately leading to tragic consequences.",
                "F. Scott Fitzgerald"),
            
            new("Ulysses",
                "Set in Dublin, the novel follows a day in the life of Leopold Bloom, an advertising salesman, as he navigates the city. The narrative, heavily influenced by Homer's Odyssey, explores themes of identity, heroism, and the complexities of everyday life. It is renowned for its stream-of-consciousness style and complex structure, making it a challenging but rewarding read.",
                "James Joyce"),
            
            new("Nineteen Eighty Four",
                "Set in a dystopian future, the novel presents a society under the total control of a totalitarian regime, led by the omnipresent Big Brother. The protagonist, a low-ranking member of 'the Party', begins to question the regime and falls in love with a woman, an act of rebellion in a world where independent thought, dissent, and love are prohibited. The novel explores themes of surveillance, censorship, and the manipulation of truth.",
                "George Orwell"),
            
            new("The Catcher in the Rye",
                "The novel follows the story of a teenager named Holden Caulfield, who has just been expelled from his prep school. The narrative unfolds over the course of three days, during which Holden experiences various forms of alienation and his mental state continues to unravel. He criticizes the adult world as \"phony\" and struggles with his own transition into adulthood. The book is a profound exploration of teenage rebellion, alienation, and the loss of innocence.",
                "J. D. Salinger"),
        });
  }
}
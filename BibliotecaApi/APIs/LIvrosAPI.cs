using Microsoft.EntityFrameworkCore;

public static class LivrosApi {

    public static void MapLivrosApi(this WebApplication app)
    {

        var group = app.MapGroup("/livros");


        group.MapGet("/", async (BancoDeDados db) =>
            // SELECT * FROM Livros
            await db.Livros.ToListAsync()
        );

        group.MapPost("/", async (Livro livro, BancoDeDados db) =>
        {
            db.Livros.Add(livro);
            // INSERT INTO...
            await db.SaveChangesAsync();

            return Results.Created($"/livros/{livro.LivroId}", livro);
        }
        );

        group.MapPut("/{id}", async (int id, Livro livroAlterado, BancoDeDados db) =>
        {
            // SELECT * FROM Livros WHERE LivroId = ?
            var livro = await db.Livros.FindAsync(id);
            if (livro is null)
            {
                return Results.NotFound();
            }
            livro.Titulo = livroAlterado.Titulo;
            livro.Autor = livroAlterado.Autor;
            livro.AnoPublicacao = livroAlterado.AnoPublicacao;
            livro.Emprestimos = livroAlterado.Emprestimos;

            // UPDATE....
            await db.SaveChangesAsync();

            return Results.NoContent();
        }
        );

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            if (await db.Livros.FindAsync(id) is Livro livro)
            {
                // Operações de exclusão
                db.Livros.Remove(livro);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        }
        );
    }
}
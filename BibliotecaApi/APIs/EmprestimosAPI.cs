using Microsoft.EntityFrameworkCore;

public static class EmprestimosApi {

    public static void MapEmprestimosApi(this WebApplication app)
    {

        var group = app.MapGroup("/emprestimos");


        group.MapGet("/", async (BancoDeDados db) =>
            // SELECT * FROM Emprestimos
            await db.Emprestimos.ToListAsync()
        );

        group.MapPost("/", async (Emprestimo emprestimo, BancoDeDados db) =>
        {
            db.Emprestimos.Add(emprestimo);
            // INSERT INTO...
            await db.SaveChangesAsync();

            return Results.Created($"/emprestimos/{emprestimo.EmprestimoId}", emprestimo);
        }
        );

        group.MapPut("/{id}", async (int id, Emprestimo emprestimoAlterado, BancoDeDados db) =>
        {
            // SELECT * FROM Emprestimos WHERE EmprestimoId = ?
            var emprestimo = await db.Emprestimos.FindAsync(id);
            if (emprestimo is null)
            {
                return Results.NotFound();
            }
            emprestimo.Livro = emprestimoAlterado.Livro;
            emprestimo.Usuario = emprestimoAlterado.Usuario;
            emprestimo.DataEmprestimo = emprestimoAlterado.DataEmprestimo;
            emprestimo.DataDevolucao = emprestimoAlterado.DataDevolucao;

            // UPDATE....
            await db.SaveChangesAsync();

            return Results.NoContent();
        }
        );

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            if (await db.Emprestimos.FindAsync(id) is Emprestimo emprestimo)
            {
                // Operações de exclusão
                db.Emprestimos.Remove(emprestimo);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        }
        );
    }
}
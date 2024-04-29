using Microsoft.EntityFrameworkCore;

public static class UsuariosApi {

    public static void MapUsuariosApi(this WebApplication app)
    {

        var group = app.MapGroup("/usuarios");


        group.MapGet("/", async (BancoDeDados db) =>
            // SELECT * FROM Usuarios
            await db.Usuarios.ToListAsync()
        );

        group.MapPost("/", async (Usuario usuario, BancoDeDados db) =>
        {
            db.Usuarios.Add(usuario);
            // INSERT INTO...
            await db.SaveChangesAsync();

            return Results.Created($"/usuarios/{usuario.UsuarioId}", usuario);
        }
        );

        group.MapPut("/{id}", async (int id, Usuario usuarioAlterado, BancoDeDados db) =>
        {
            // SELECT * FROM Usuarios WHERE UsuarioId = ?
            var usuario = await db.Usuarios.FindAsync(id);
            if (usuario is null)
            {
                return Results.NotFound();
            }
            usuario.Nome = usuarioAlterado.Nome;
            usuario.Email = usuarioAlterado.Email;
            usuario.Emprestimos = usuarioAlterado.Emprestimos;

            // UPDATE....
            await db.SaveChangesAsync();

            return Results.NoContent();
        }
        );

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            if (await db.Usuarios.FindAsync(id) is Usuario usuario)
            {
                // Operações de exclusão
                db.Usuarios.Remove(usuario);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        }
        );
    }
}
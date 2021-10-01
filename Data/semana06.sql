USE Neptuno

GO
ALTER PROC USP_InsCategoria
	@idcategoria INT,
	@nombreCategoria varchar(100),
	@descripcion text
AS
BEGIN
	INSERT INTO categorias(idcategoria, 
						   nombrecategoria, 
						   descripcion)
	VALUES (@idcategoria, 
			@nombreCategoria, 
			@descripcion)
END

GO
CREATE PROC USP_UpdCategoria
	@idcategoria INT,
	@nombrecategoria VARCHAR(100),
	@descripcion TEXT
AS
BEGIN
	UPDATE categorias SET nombrecategoria=@nombrecategoria, 
						  descripcion=@descripcion
	WHERE idcategoria=@idcategoria
END

GO
CREATE PROC USP_DelCategoria
	@idcategoria INT
AS
BEGIN
	DELETE FROM categorias WHERE idcategoria=@idcategoria
END

GO
ALTER PROC USP_GetCategoria
	@idcategoria INT=0
AS
BEGIN
	SELECT idcategoria, 
		   nombrecategoria, 
		   descripcion 
	FROM categorias
	WHERE idcategoria=@idcategoria OR @idcategoria=0
END

select * from categorias
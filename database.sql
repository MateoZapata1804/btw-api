CREATE DATABASE IF NOT EXISTS bythewave;
USE bythewave;

CREATE TABLE usuarios(
	id int PRIMARY KEY AUTO_INCREMENT,
    nombres varchar(40) NOT NULL,
    apellido1 varchar(30) NOT NULL,
    apellido2 varchar(30) DEFAULT NULL,
    email varchar(80) NOT NULL UNIQUE,
    rol int NOT NULL,
    clave varchar(255) NOT NULL
);

CREATE TABLE roles(
	id int PRIMARY KEY AUTO_INCREMENT,
    nombre_rol varchar(40) NOT NULL UNIQUE
);

ALTER TABLE usuarios AUTO_INCREMENT = 100,
ADD FOREIGN KEY (rol) REFERENCES roles(id);

INSERT INTO roles(nombre_rol) VALUES ("Visitante");
INSERT INTO roles(nombre_rol) VALUES ("Empleado");
INSERT INTO roles(nombre_rol) VALUES ("Coordinador");
INSERT INTO roles(nombre_rol) VALUES ("Director");
INSERT INTO roles(nombre_rol) VALUES ("Gerente");
INSERT INTO roles(nombre_rol) VALUES ("Superadmin");

INSERT INTO usuarios(nombres,apellido1,apellido2,email,rol,clave)
VALUES ("Administrador", "Crud", "", "admin@bythewave.com", 6, "c3VwZXI0ZG1pbkJUVyE="); -- "pass: super4dminBTW!"
CREATE TABLE mensagens (
    id serial PRIMARY KEY,
    assunto VARCHAR(255),
    remetente VARCHAR(255),
    destinatario VARCHAR(255),
    data TIMESTAMP,
    corpo_texto TEXT,
    servidor_email VARCHAR(255)
);
# Protocolo Placa Secullum

Este documento define o protocolo de comunicação usado pela placa secullum.

Os valores descritos neste documento estão no formato decimal.

Utilize a porta 1999 para realizar a comunicação com a placa.

## Estrutura dos comandos

Todo comando seguirá a seguinte estrutura.

| Campo               | Tamanho em bytes    | Descrição                                  |
| ------------------- | ------------------- | ------------------------------------------ |
| Start               | 2                   | Fixo 19 no primeiro byte, 99 no segundo    |
| Tamanho             | 2                   | Tamanho dos dados, MSB depois LSB          |
| Comando             | 1                   | Identificador do comando                   |
| Dados               | variável            | Dados variam para cada comando             |
| Checksum            | 1                   | XOR do start até o final dos dados         |

## Comandos

- Comandos com códigos 1xx são enviados para a placa secullum.
- Comandos com códigos 2xx a placa secullum é quem envia.
- Outros comandos podem ser enviados por qualquer um dos lados.

### ACK

Informa que a operação foi processada com sucesso. Não possui dados.

Código do comando: 1

Exemplo:

19, 99, 0, 0, 1, 113

### NACK

Informa que houve um erro na operação.

Código do comando: 2

| Campo               | Tamanho em bytes    | Descrição                                  |
| ------------------- | ------------------- | ------------------------------------------ |
| Motivo              | 1                   | Consultar tabela de erros de cada comando  |

Exemplo com código de erro 20:

19, 99, 0, 1, 2, 20, 103

### Acionar relé por tempo

Enviado para a placa acionar um relé durante certo tempo.

Código do comando: 100

| Campo               | Tamanho em bytes    | Descrição                                  |
| ------------------- | ------------------- | ------------------------------------------ |
| Número              | 1                   | Número do relé                             |
| Tempo               | 2                   | Em milisegundos, MSB depois LSB            |

Exemplo para acionar o relé 2 por 3 segundos:

Dec 019, 099, 000, 003, 100, 002, 011, 184, 166 <br>
Hex 13 63 00 03 64 02 0B BB A6

### Acionar relé continuamente

Comando enviado para a placa acionar um relé por tempo indeterminado.

Código do comando: 101

| Campo               | Tamanho em bytes    | Descrição                                  |
| ------------------- | ------------------- | ------------------------------------------ |
| Número              | 1                   | Número do relé                             |

Exemplo para acionar o relé 1:

Dec 019, 099, 000, 001, 101, 001, 021 <br>
Hex 13 63 00 01 65 01 15

### Desligar relé

Comando enviado para a placa desligar um relé por tempo indeterminado.

Código do comando: 102

| Campo               | Tamanho em bytes    | Descrição                                  |
| ------------------- | ------------------- | ------------------------------------------ |
| Número              | 1                   | Número do relé                             |

Exemplo para desligar o relé 2:

Dec 019, 099, 000, 001, 102, 002, 127 <br>
Hex 13 63 00 01 66 02 7F

### Informar estado do sensor

Comando enviado pela placa para informar a troca de estado de um sensor.

Código do comando: 200

| Campo               | Tamanho em bytes    | Descrição                                  |
| ------------------- | ------------------- | ------------------------------------------ |
| Número              | 1                   | Número do sensor                           |
| Estado              | 1                   | 0 para desligado, 1 para ligado            |

Exemplo informando que o sensor 2 está ligado:

19, 99, 0, 2, 200, 2, 1, 185

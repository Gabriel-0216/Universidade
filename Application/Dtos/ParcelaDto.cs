﻿namespace Application.Dtos;

public class ParcelaDto
{
    public int Id { get; set; }
    public int NumeroParcela { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime DataCriacao { get; set; }
    public bool Pago { get; set; }
    public ParcelaDto()
    {
        
    }

    public ParcelaDto(int id, int numeroParcela, decimal valor,
        DateTime dataVencimento, DateTime dataCriacao, bool pago)
    {
        Id = id;
        NumeroParcela = numeroParcela;
        Valor = valor;
        DataVencimento = dataVencimento;
        DataCriacao = dataCriacao;
        Pago = pago;
    }
    
}
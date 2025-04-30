using System.ComponentModel;

namespace BaseModel.Domain.Enums
{
    public enum TypeMovimentStockEnum
    {
        [Description("Entrada")]
        Entry = 1,
        [Description("Saída")]
        Exit = 2,
    }
}
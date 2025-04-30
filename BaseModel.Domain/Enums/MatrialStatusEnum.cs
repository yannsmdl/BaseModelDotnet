using System.ComponentModel;

namespace BaseModel.Domain.Enums
{
    public enum MatrialStatusEnum
    {
        [Description("Solteiro")]
        Single = 1,
        [Description("Casado")]
        Married = 2,
        [Description("Separado")]
        Separated = 3,
        [Description("Divorciado")]
        Divorced = 4,
        [Description("Viúvo")]
        Widower = 5,
        [Description("União Estável")]
        StableUnion = 6,
    }
}
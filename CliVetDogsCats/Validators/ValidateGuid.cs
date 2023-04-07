namespace CliVetDogsCats.API.Validators
{
    public static class ValidateGuid
    {
        public static bool BeAValidGuid(Guid unvalidateGuid)
        {
            try
            {
                if (unvalidateGuid != Guid.Empty)
                {
                    if (Guid.TryParse(unvalidateGuid.ToString(), out Guid validateGuid))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

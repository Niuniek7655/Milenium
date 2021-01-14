namespace Model
{
    public class ModelValidator : IModelValidator
    {
        public bool Validate(TestObject model)
        {
            if(model == null || (model.Id == null || string.IsNullOrWhiteSpace(model.Name)))
            {
                return false;
            }
            return true;
        }
    }
}

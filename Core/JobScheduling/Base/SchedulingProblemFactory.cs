namespace Core.JobScheduling.Base
{
    public static class SchedulingProblemFactory
    {
        public static SchedulingProblem Create(SchedulingProblemType type, string inputData)
        {
            switch(type)
            {
                case SchedulingProblemType.FlowShop:
                    return new FlowShop.SchedulingProblem(inputData);
                case SchedulingProblemType.JobShop:
                    return new JobShop.SchedulingProblem(inputData);
                default:
                    return new OpenShop.SchedulingProblem(inputData);
            }
        }

        public static SchedulingProblem Create(string type, string inputData)
        {
            switch(type)
            {
                case "f":
                    return new FlowShop.SchedulingProblem(inputData);
                case "j":
                    return new JobShop.SchedulingProblem(inputData);
                default:
                    return new OpenShop.SchedulingProblem(inputData);
            }
        }
    }
}
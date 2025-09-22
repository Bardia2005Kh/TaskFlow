using TaskFlow.Application.IRepository;
using TaskFlow.Application.IServices;
using static TaskFlow.Domain.Models.TaskItem;

namespace TaskFlow.WebAPI.BackgroundServices
{
    public class AutoDeadlineChecherService : BackgroundService
    {
        private readonly IServiceScopeFactory scopeFactory;
        private readonly ILogger<AutoDeadlineChecherService> logger;

        public AutoDeadlineChecherService(IServiceScopeFactory scopeFactory, ILogger<AutoDeadlineChecherService> logger)
        {
            this.scopeFactory = scopeFactory;
            this.logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = scopeFactory.CreateScope();
                var repo = scope.ServiceProvider.GetRequiredService<ITaskRepository>();

                var overdueTasks = await repo.GetOverdueOpenTasksAsync(DateTime.UtcNow);
                foreach (var task in overdueTasks)
                {
                    task.TaskStatus = Status.OverDue;
                }

                await repo.SaveChangesAsync();

                logger.LogInformation($"{overdueTasks.Count} tasks set to Overdue");
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }

            
        }
    }
}

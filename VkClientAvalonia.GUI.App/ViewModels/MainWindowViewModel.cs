using System.Reactive;
using ReactiveUI;

namespace VkClientAvalonia.GUI.App.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        
        
        
        private bool _u1V;

        public bool u1V
        {
            get => _u1V;
            set => this.RaiseAndSetIfChanged(ref _u1V, value);
        }
        
        private bool _u2V;

        public bool u2V
        {
            get => _u2V;
            set => this.RaiseAndSetIfChanged(ref _u2V, value);
        }
        public ReactiveCommand<Unit, Unit> But { get; init; }
        
        public MainWindowViewModel() {
            u1V = false;
            u2V = true;

            But = ReactiveCommand.Create(() => {
                u1V = !u1V;
                u2V = !u2V;
            });
        }
        
    }
}
var TechHome;
(function (TechHome) {
    var Services;
    (function (Services) {
        var Tasks;
        (function (Tasks) {
            (function (State) {
                State[State["Ready"] = 0] = "Ready";
                State[State["Downloading"] = 1] = "Downloading";
                State[State["Completed"] = 2] = "Completed";
            })(Tasks.State || (Tasks.State = {}));
            var State = Tasks.State;
        })(Tasks = Services.Tasks || (Services.Tasks = {}));
    })(Services = TechHome.Services || (TechHome.Services = {}));
})(TechHome || (TechHome = {}));
//# sourceMappingURL=Enums.js.map
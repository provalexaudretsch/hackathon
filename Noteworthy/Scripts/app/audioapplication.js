function AudioInit(viewmodel){
    var isRecording = false;
    viewModel.StartRecording = function () {

        if (!isRecording) {
            $('#recordingButton').html('Recording...');
            //YOUR CODE HERE
        }
        else {
            viewModel.EndRecording();

            $('#recordingButton').html('Click to record.');
        }
        isRecording = !isRecording;
    };

    viewModel.EndRecording = function () {

        var title = $('#recordingInput').val();
        var content = "foo recording";
        var postData = {
            "content": content,
            "title": title,
            "userId": viewModel.CurrentUser.Id
        };
        var note = $.post("/Home/RecordNote", postData, function (n) {

            viewModel.Notes.push(n);
        });
    };
    viewModel.Notes = ko.observableArray(viewModel.Notes);
    ko.applyBindings(viewModel);
}
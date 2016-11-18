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

        var title = $("#topicInput").val();
        var content = "foo recording";
        var postData = {
            "content": content,
            "title": title,
            "userId": viewModel.CurrentUser.Id
        };
        var note = $.post("/Home/RecordNote?title="+title+"&content="+content+"&userId="+viewModel.CurrentUser.Id, postData, function (n) {

            viewModel.Notes.unshift(n);
        });
    };
    viewModel.Notes = ko.observableArray(viewModel.Notes);
    ko.applyBindings(viewModel);
}
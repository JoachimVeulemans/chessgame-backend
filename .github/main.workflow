workflow "Add reviewers/assignees to Pull Requests" {
  on = "pull_request"
  resolves = "Auto Assign"
}

action "Auto Assign" {
  uses = "kentaro-m/auto-assign@master"
  secrets = ["GITHUB_TOKEN"]
}

param(
  [string]$server = "http://localhost:64884",
  [string]$search = ""
)

$url = "{0}/api/people/{1}" -f $server, $search

Invoke-RestMethod -Method Get -Uri $url
$json = $response | ConvertTo-Json
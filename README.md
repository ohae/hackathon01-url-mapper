# Hackathon Holiday

## URL Mapper

* Create Structure which can
 * Match Y/N
 * Extract Vars
Constraints: NO REGEX

[1] https://mana.com/linkto/{link-id}
[2] http://google.com/?s={keyword}
[3] https://mana.com/app/{app/-id}/services/{service-id}

https://mana.com/linkto/A2348
Match [1] -> {link-id} = A2348

https://mana.com/app/di394/services/services/878
Match [3] -> {app/-id} = di394,
      {service-id} = 878

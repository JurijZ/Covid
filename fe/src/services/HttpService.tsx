export interface HttpRequest<REQB> {
    path: string,
    method?: string,
    body?: REQB,
    accessToken?: string
}

export interface HttpResponse<RESB> extends Response {
    parsedBody?: RESB
}

export const http = <REQB, RESB>(config: HttpRequest<REQB>,): Promise<HttpResponse<RESB>> => {
    return new Promise((resolve, reject) => {
        
        console.log("JSON: " + JSON.stringify(config.body));

        const request = new Request('http://localhost:5000' + `${config.path}`, {
            method: config.method || 'get',
            headers: {'Content-Type': 'application/json'},
            body: config.body ? JSON.stringify(config.body) : undefined,
        });

        console.log(request);
        console.log(request.body);
        

        if (config.accessToken){
            request.headers.set('Authorization', `Bearer ${config.accessToken}`);
        }

        let response: HttpResponse<RESB>;

        fetch(request)
            .then(res => {
                response = res;
                if (res.headers.get('Content-Type') || ''.indexOf('json') > 0){
                    return res.json();
                } else {
                    resolve(response);
                }
            })
            .then(body => {
                if (response.ok){
                    response.parsedBody = body;
                    resolve(response);
                } else {
                    reject(response);
                }
            })
            .catch(err => {
                console.error(err);
                reject(err);
            });
    })
}
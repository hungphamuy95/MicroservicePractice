import Oidc from 'oidc-client';

const config = {
    userStore: new Oidc.WebStorageStateStore({store: window.localStorage}),
    authority: "http://docker.for.win.localhost:5001",
    client_id: "js",
    redirect_uri: "http://docker.for.win.localhost:5007",
    response_type: "code",
    scope:"api1",
    post_logout_redirect_uri : "https://docker.for.win.localhost:5003",

}

const mgr = new Oidc.UserManager(config);
export default mgr;
import auth from './AuthService';
import router from './../router/index'

export default (to, from, next) => {
    auth.getUser().then((user)=>{
        if(user !== null && !user.expired){
            next();
        }else{
            router.push('/');
        }
    })
}
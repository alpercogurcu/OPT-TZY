const jwt = require('jsonwebtoken');

const dotenv = require('dotenv');
dotenv.config();


const {
    secret_KEY
} = process.env;

module.exports =(req,res,next) => {
    try{
        const token = req.headers.authorization.split(" ")[1];
      
        const decodedToken = jwt.verify(token, secret_KEY)
        next();
        //console.log(token);
    }
    catch (err)
    {
        return res.status(401).send(
            {
                message: 'Yetkisiz Erişim',
                status: -1
            }
        )
    }
}
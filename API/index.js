'use strict';
const express = require("express");
const config = require("./config");
const cors = require("cors");
const bodyParser = require("body-parser");
const helmet = require('helmet');
const jwt = require('jsonwebtoken');
const sql = require('mssql');
const checkJWT = require('./auth');
const app = express();



const dotenv = require('dotenv');
dotenv.config();

app.use(cors());
app.use(helmet());
app.use(bodyParser.json());

const {
    secret_KEY
} = process.env;


app.get('/', (req, res) => {

    /*
        sql.connect(config.sql).then(pool => {
            return pool.request().query("select * from stok_StokBilgileri")
        }).then(result => res.send(result.recordset));
    */


});

app.get('/dosyaGetir', checkJWT, (req, res) => {

    res.download("C:/Users/Administrator/Desktop/1069_OPEQ_ARM_B/1069_ARA_PARCA.SLDPRT");

})

app.get('/projeler', checkJWT, (req, res) => {
    sql.connect(config.sql).then(pool => {
        return pool.request().execute("WEB_GET_Proje_SiparisDetay")
    })
        .then(result => res.send(result.recordset))
});


app.get('/konumagoremalzemelistesi', checkJWT, (req, res) => {

    sql.connect(config.sql).then(pool => {
        return pool.request().execute("WEB_GET_KonumaGoreMalzemeListesi")
    })
        .then(result => res.send(result.recordset))
});


app.get('/depoveisletmebilgileri', checkJWT, (req, res) => {


    sql.connect(config.sql).then(pool => {
        return pool.request().execute("WEB_GET_DepoVeIsletmeBilgileri")
    })
        .then(result => res.send(result.recordsets))
});

app.get('/irsaliyeler/:projeID', checkJWT, (req, res) => {


    sql.connect(config.sql).then(pool => {
        return pool.request()
            .input("sip_DetayID", sql.Int, req.params.projeID)
            .execute("WEB_GET_ProjeBazliIrsaliyeListesi")
    })
        .then(result => res.send(result.recordset))

});

app.get('/irsaliye/:irsno', checkJWT, (req, res) => {



    sql.connect(config.sql).then(pool => {
        return pool.request()
            .input("irsaliyeNo", sql.NVarChar, req.params.irsno)
            .execute("WEB_GET_IrsaliyeDetay")
    })
        .then(result => res.send(result.recordsets))

});



app.get('/imalat/kalanuretim', checkJWT, (req,res) => {

    sql.connect(config.sql).then(pool => {
        return pool.request()
            .execute("GET_URETIM_TedarikciKalanUretimSayisi")
    })
        .then(result => res.send(result.recordset))
});


app.post('/login', async (req, res) => {

    try {
        const { kullaniciadi, parola } = req.body;


        const dbKullanici = await sql.connect(config.sql).then(pool => {
            return pool.request()
                .input("username", sql.NVarChar, kullaniciadi)
                .input("password", sql.NVarChar, parola)
                .execute("kullaniciLogin")
        });
        const token = jwt.sign(
            {
                kullaniciadi: dbKullanici.recordset[0].kullaniciadi,
                ad: dbKullanici.recordset[0].adsoyad,
                token: dbKullanici.recordset[0].token,

                //   exp: Math.floor(Date.now() / 1000) + 60,
            },
            secret_KEY,
            {
                expiresIn: '1d'
            });


        res.send(token);

    }
    catch (err) {
        console.log(err);
        res.status(403).send(
            {
                message: 'Hatalı Kullanıcı Adı veya Parola',
                status: -1
            }
        )
    }
})

app.post('/irsaliyeolustur', checkJWT, async (req, res) => {

    //  res.send(req.body[0]);
    try {


        let irsaliyebaslik = {
            tedarikci: req.body.tedarikci,
            hedef: req.body.hedef.id,
            hedefBirimDepo: req.body.hedefBirimDepo,
            cikisBirimDepo: req.body.cikisBirimDepo,
            kullaniciadi: req.body.kullaniciadi,
            Aciklama: req.body.Aciklama,
            irsaliye_kod_id: req.body.irsaliye_kod_id
        }

        const itemList = req.body.items;




        const dbIrsaliyeBaslikEkle = await sql.connect(config.sql).then(pool => {
            return pool.request()
                .input("tedarikci", sql.Int, irsaliyebaslik.tedarikci)
                .input("hedefDepo", sql.Int, irsaliyebaslik.hedef)
                .input("aciklama", sql.NVarChar, irsaliyebaslik.Aciklama)
                .input("hedefBirimDepo", sql.Bit, irsaliyebaslik.hedefBirimDepo)
                .input("cikisBirimDepo", sql.Bit, irsaliyebaslik.cikisBirimDepo)
                .input("kullaniciadi", sql.NVarChar, irsaliyebaslik.kullaniciadi)
                .input("irsaliye_kod_id", sql.Int, irsaliyebaslik.irsaliye_kod_id)
                .execute("INSERT_IrsaliyeBaslik")
        });



        const irsaliyeID = dbIrsaliyeBaslikEkle.recordset[0].id;


        for (let i = 0; i < itemList.length; i++) {

            const dbIrsaliyeDetayEkle = await sql.connect(config.sql).then(pool => {
                return pool.request()
                    .input("irsaliye_id", sql.Int, irsaliyeID)
                    .input("stok_id", sql.Int, itemList[i].stok_id)
                    .input("miktar", sql.NVarChar, itemList[i].transferMiktari)
                    .input("uzunluk", sql.NVarChar, itemList[i].uzunluk)
                    .input("kullanici", sql.NVarChar, itemList[i].stok_id)
                    .input("sip_DetayID", sql.Int, itemList[i].siparis_DetayID)
                    .execute("INSERT_IrsaliyeDetay")
            });

        }

        res.send(
            dbIrsaliyeBaslikEkle.recordset
        );









    }
    catch (err) {
        console.log(err);
        res.status(501).send(
            {
                message: 'Hata',
                status: -1
            }
        )
    }


});





app.post('/isletme/stokekle', checkJWT, async (req, res) => {

    //  res.send(req.body[0]);
    try {
        console.log(req.body);
        let stokBilgileri = {
            stok_id : req.body.stok_id,
            tedarikci : req.body.tedarikci,
            miktar: req.body.miktar,
            irsaliye_detayID : req.body.irsaliye_detayID,
            irsaliye_id : req.body.irsaliye_id,
          };

        const dbStokEkle = await sql.connect(config.sql).then(pool => {
            return pool.request()
                .input("stok_id", sql.Int, stokBilgileri.stok_id)
                .input("isletme_id", sql.Int, stokBilgileri.tedarikci)
                .input("miktar", sql.Float, stokBilgileri.miktar)
                .input("irsaliye_detayID", sql.Int, stokBilgileri.irsaliye_detayID)
                .input("irsaliye_id", sql.Int, stokBilgileri.irsaliye_id)
                .execute("INSERT_IsletmeStok")
        });



        res.send(
            dbStokEkle.recordset
        );









    }
    catch (err) {
        console.log(err);
        res.status(501).send(
            {
                message: 'Hata',
                status: -1
            }
        )
    }


})

app.listen(config.port, () => {
    console.log("Server dinleniyor.")
});




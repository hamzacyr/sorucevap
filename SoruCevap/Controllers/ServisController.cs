using SoruCevap.Models;
using SoruCevap.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoruCevap.Controllers
{
    public class ServisController : ApiController
    {
        Database1Entities db = new Database1Entities();
        SonucModel sonuc = new SonucModel();

        // ------------------------------------------------------------------
        // CEVAPLAR
        // ------------------------------------------------------------------
        [HttpGet]
        [Route("api/cevaplar")]
        public List<CevapModel> CevapListe()
        {
            List<CevapModel> cevaplar = db.Cevaps.Select(x => new CevapModel()
            {
                Id = x.Id,
                Icerik = x.Icerik,
                SoruId = x.SoruId,
                UyeId = x.UyeId
            }).ToList();

            return cevaplar;
        }

        [HttpGet]
        [Route("api/cevaplar/{id}")]
        public CevapModel CevapById(int id)
        {
            CevapModel cevap = db.Cevaps.Where(s => s.Id == id).Select(x => new CevapModel()
            {
                Id = x.Id,
                Icerik = x.Icerik,
                SoruId = x.SoruId,
                UyeId = x.UyeId

            }).SingleOrDefault();

            return cevap;
        }

        [HttpPost]
        [Route("api/cevaplar")]
        public SonucModel CevapOlustur([FromBody] CevapModel model)
        {
            db.Cevaps.Add(new Cevap()
            {
                Icerik = model.Icerik,
                SoruId = model.SoruId,
                UyeId = model.UyeId

            });

            db.SaveChanges();

            sonuc.Islem = true;
            sonuc.Mesaj = "Cevap Oluşturuldu";

            return sonuc;
        }

        [HttpPut]
        [Route("api/cevaplar/{id}")]
        public SonucModel CevapGuncelle(int id, [FromBody] CevapModel model)
        {
            Cevap cevap = db.Cevaps.Where(s => s.Id == id).SingleOrDefault();

            if (cevap == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            cevap.Icerik = model.Icerik;

            db.SaveChanges();

            sonuc.Islem = true;
            sonuc.Mesaj = "Cevap Güncellendi";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/cevaplar/{id}")]
        public SonucModel CevapSil(int id)
        {
            Cevap cevap = db.Cevaps.Where(s => s.Id == id).SingleOrDefault();

            if (cevap == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            db.Cevaps.Remove(cevap);
            db.SaveChanges();

            sonuc.Islem = true;
            sonuc.Mesaj = "Cevap Silindi";
            return sonuc;
        }



        // ------------------------------------------------------------------
        // SORULAR
        // ------------------------------------------------------------------
        [HttpGet]
        [Route("api/sorular")]
        public List<SoruModel> SoruListe()
        {
            List<SoruModel> sorular = db.Sorus.Select(x => new SoruModel()
            {
                Id = x.Id,
                Baslik = x.Baslik,
                Icerik = x.Icerik,
                Tarih = x.Tarih,
                UyeId = x.UyeId,
                KatId = x.KatId

            }).ToList();

            return sorular;
        }

        [HttpGet]
        [Route("api/sorular/{id}")]
        public SoruModel SoruById(int id)
        {
            SoruModel soru = db.Sorus.Where(s => s.Id == id).Select(x => new SoruModel()
            {
                Id = x.Id,
                Baslik = x.Baslik,
                Icerik = x.Icerik,
                Tarih = x.Tarih,
                UyeId = x.UyeId,
                KatId = x.KatId

            }).SingleOrDefault();

            return soru;
        }

        [HttpPost]
        [Route("api/sorular")]
        public SonucModel SoruOlustur(SoruModel model)
        {
            db.Sorus.Add(new Soru()
            {
                Baslik = model.Baslik,
                Icerik = model.Icerik,
                KatId = model.KatId,
                Tarih = model.Tarih,
                UyeId = model.UyeId

            });

            db.SaveChanges();

            sonuc.Islem = true;
            sonuc.Mesaj = "Soru Oluşturuldu";

            return sonuc;
        }

        [HttpPut]
        [Route("api/sorular/{id}")]
        public SonucModel SoruGuncelle(int id, [FromBody] SoruModel model)
        {

            Soru soru = db.Sorus.Where(s => s.Id == id).SingleOrDefault();

            if (soru == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            soru.Baslik = model.Baslik;
            soru.Icerik = model.Icerik;
            soru.KatId = model.KatId;

            db.SaveChanges();

            sonuc.Islem = true;
            sonuc.Mesaj = "Soru Güncellendi";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/sorular/{id}")]
        public SonucModel SoruSil(int id)
        {
            Soru soru = db.Sorus.Where(s => s.Id == id).SingleOrDefault();

            if (soru == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            db.Sorus.Remove(soru);

            db.SaveChanges();

            sonuc.Islem = true;
            sonuc.Mesaj = "Soru Silindi";

            return sonuc;
        }


        // ------------------------------------------------------------------
        // UYELER
        // ------------------------------------------------------------------
        [HttpGet]
        [Route("api/uyeler")]
        public List<UyeModel> UyeListe()
        {
            List<UyeModel> uyeler = db.Uyes.Select(x => new UyeModel()
            {
                Id = x.Id,
                Ad = x.Ad,
                Soyad = x.Soyad,
                Email = x.Email,
                Rol = x.Rol,
                Sifre = x.Sifre,
            }).ToList();

            return uyeler;
        }

        [HttpGet]
        [Route("api/uyeler/{id}")]
        public UyeModel UyeById(int id)
        {
            UyeModel uye = db.Uyes.Where(s => s.Id == id).Select(x => new UyeModel()
            {
                Id = x.Id,
                Ad = x.Ad,
                Soyad = x.Soyad,
                Email = x.Email,
                Rol = x.Rol,
                Sifre = x.Sifre,

            }).SingleOrDefault();

            return uye;
        }

        [HttpPost]
        [Route("api/uyeler")]
        public SonucModel UyeOlustur([FromBody] UyeModel model)
        {
            db.Uyes.Add(new Uye()
            {
                Ad = model.Ad,
                Soyad = model.Soyad,
                Email = model.Email,
                Rol = model.Rol,
                Sifre = model.Sifre,

            });

            db.SaveChanges();

            sonuc.Islem = true;
            sonuc.Mesaj = "Uye Oluşturuldu";

            return sonuc;
        }

        [HttpPut]
        [Route("api/uyeler/{id}")]
        public SonucModel UyeGuncelle(int id, [FromBody] UyeModel model)
        {

            Uye uye = db.Uyes.Where(s => s.Id == id).SingleOrDefault();

            if (uye == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            uye.Ad = model.Ad;
            uye.Soyad = model.Soyad;
            uye.Email = model.Email;
            uye.Rol = model.Rol;
            uye.Sifre = model.Sifre;

            db.SaveChanges();

            sonuc.Islem = true;
            sonuc.Mesaj = "Üye Güncellendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/uyeler/{id}")]
        public SonucModel UyeSil(int id)
        {
            Uye uye = db.Uyes.Where(s => s.Id == id).SingleOrDefault();

            if (uye == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            db.Uyes.Remove(uye);
            db.SaveChanges();

            sonuc.Islem = true;
            sonuc.Mesaj = "Üye Silindi";
            return sonuc;
        }


        // ------------------------------------------------------------------
        // KATEGORİLER
        // ------------------------------------------------------------------
        [HttpGet]
        [Route("api/kategoriler")]
        public List<KategoriModel> KategoriListe()
        {
            List<KategoriModel> kategoriler = db.Kategoris.Select(x => new KategoriModel()
            {
                Id = x.Id,
                KatAdi = x.KatAdi
            }).ToList();

            return kategoriler;
        }

        [HttpGet]
        [Route("api/kategoriler/{id}")]
        public KategoriModel KategoriById(int id)
        {
            KategoriModel kategori = db.Kategoris.Where(s => s.Id == id).Select(x => new KategoriModel()
            {
                Id = x.Id,
                KatAdi = x.KatAdi
            }).SingleOrDefault();

            return kategori;
        }

        [HttpPost]
        [Route("api/kategoriler")]
        public SonucModel KategoriOlustur([FromBody] KategoriModel model)
        {
            db.Kategoris.Add(new Kategori()
            {
                KatAdi = model.KatAdi
            });

            db.SaveChanges();

            sonuc.Islem = true;
            sonuc.Mesaj = "Kategori Oluşturuldu";
            return sonuc;
        }

        [HttpPut]
        [Route("api/kategoriler/{id}")]
        public SonucModel KategoriGuncelle(int id, [FromBody] KategoriModel model)
        {
            Kategori kategori = db.Kategoris.Where(s => s.Id == id).SingleOrDefault();

            if (kategori == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            kategori.KatAdi = model.KatAdi;

            db.SaveChanges();

            sonuc.Islem = true;
            sonuc.Mesaj = "Kategori Güncellendi";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/kategoriler/{id}")]
        public SonucModel KategoriSil(int id)
        {
            Kategori kategori = db.Kategoris.Where(s => s.Id == id).SingleOrDefault();

            if (kategori == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            db.Kategoris.Remove(kategori);
            db.SaveChanges();

            sonuc.Islem = true;
            sonuc.Mesaj = "Kategori Silindi";
            return sonuc;
        }

    }
}

using AutoMapper;
using Cineminha.Aplicacao.Interfaces;
using Cineminha.Aplicacao.ViewModels;
using Cineminha.Dominio.Entidades;
using Cineminha.Dominio.Interfaces;
using Cineminha.Dominio.Interfaces.Repositorios;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace Cineminha.Aplicacao.Servicos
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        private readonly string _key = "caf3d2b673414f2ea28be11e26003bf8";
        private readonly IMapper _mapper;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioAplicacao(IMapper mapper, IUsuarioRepositorio usuarioRepositorio)
        {
            _mapper = mapper;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public UsuarioViewModel ObterPorId(int id)
        {
            return _mapper.Map<UsuarioViewModel>(_usuarioRepositorio.ObterPorId(id));
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioRepositorio.ObterTodos());
        }

        public IEnumerable<UsuarioViewModel> Procurar(Expression<Func<Usuario, bool>> expressao)
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioRepositorio.Procurar(expressao));
        }

        public IEnumerable<UsuarioViewModel> ProcurarComEspecificacao(IEspecificacao<Usuario> especificacao = null)
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioRepositorio.ProcurarComEspecificacao(especificacao));
        }

        public void Adicionar(UsuarioViewModel obj)
        {
            _usuarioRepositorio.Adicionar(_mapper.Map<Usuario>(obj));
        }

        public void Atualizar(UsuarioViewModel obj)
        {
            _usuarioRepositorio.Atualizar(_mapper.Map<Usuario>(obj));
        }

        public void Remover(int id)
        {
            _usuarioRepositorio.Remover(id);
        }

        public string EncryptPassword(string cleartext)
        {
            var iv = new byte[16];
            byte[] array;

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_key);
                aesAlg.IV = iv;
                using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(cleartext);
                            }
                            array = msEncrypt.ToArray();
                        }
                    }
                }
            }
            return Convert.ToBase64String(array);
        }

        public string DecryptPassword(string cipherText)
        {
            var fullCipher = Convert.FromBase64String(cipherText);
            var iv = new byte[16];
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_key);
                aesAlg.IV = iv;
                using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                {
                    using (var msDecrypt = new MemoryStream(fullCipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
    }
}
﻿using Krypton.Toolkit;

namespace LocadoraFCVSJ.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract void Inserir();
        public abstract void Editar();
        public abstract void Excluir();
        public abstract KryptonForm ObterTela();
    }
}
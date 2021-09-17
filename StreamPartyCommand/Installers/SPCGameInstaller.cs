﻿using SiraUtil;
using StreamPartyCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace StreamPartyCommand.Installers
{
    public class SPCGameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //this.Container.BindInterfacesAndSelfTo<StreamPartyCommandController>().FromNewComponentOnNewGameObject(nameof(StreamPartyCommandController)).AsCached();
            this.Container.BindMemoryPool<DummyBomb, DummyBomb.Pool>().WithFixedSize(64).FromNewComponentOnNewGameObject();
            this.Container.BindMemoryPool<FlyingBombNameEffect, FlyingBombNameEffect.Pool>().WithFixedSize(8).FromNewComponentOnNewGameObject();
            this.Container.BindInterfacesAndSelfTo<DummyBombObjectSpowner>().FromNewComponentOnNewGameObject(nameof(DummyBombObjectSpowner)).AsCached();
            this.Container.BindInterfacesAndSelfTo<DummyBombExprosionEffect>().FromNewComponentOnNewGameObject(nameof(DummyBombExprosionEffect)).AsCached();
            this.Container.BindInterfacesAndSelfTo<BombEffectSpowner>().FromNewComponentOnNewGameObject(nameof(BombEffectSpowner)).AsCached();
        }
    }
}

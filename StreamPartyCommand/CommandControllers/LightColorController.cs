﻿using ChatCore.Interfaces;
using StreamPartyCommand.Configuration;
using StreamPartyCommand.HarmonyPathches;
using StreamPartyCommand.Interfaces;
using StreamPartyCommand.Models;
using StreamPartyCommand.Staics;
using StreamPartyCommand.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace StreamPartyCommand.CommandControllers
{
    public class LightColorController : MonoBehaviour, ICommandable
    {
        private void Start()
        {
            GetNormalColorPatch.Enable = !this._util.IsNoodle && !this._util.IsChroma;
        }

        public string Key => CommandKey.LIGHT_COLOR;

        public void Execute(IChatService service, IChatMessage message)
        {
            if (PluginConfig.Instance.IsPratformColorEnable != true) {
                return;
            }
            var prams = message.Message.Split(' ');
            if (prams.Length != 3) {
                return;
            }
            var leftColor = prams[1];
            var rightColor = prams[2];
            if (ColorUtil.Colors.TryGetValue(leftColor, out var color0)) {
                GetNormalColorPatch.LeftColor = color0;
            }
            if (ColorUtil.Colors.TryGetValue(rightColor, out var color1)) {
                GetNormalColorPatch.RightColor = color1;
            }
        }
        private BeatmapUtil _util;
        [Inject]
        public void Constractor(ColorScheme scheme, BeatmapUtil util)
        {
            this._util = util;
            GetNormalColorPatch.RightColor = scheme.environmentColor0;
            GetNormalColorPatch.LeftColor = scheme.environmentColor1;
        }
	}
}

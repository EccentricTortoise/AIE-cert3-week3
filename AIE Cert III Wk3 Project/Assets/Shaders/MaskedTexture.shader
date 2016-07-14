//----------------------------------------------------------------
//This shader was created by a user on the Unity Forums, Ablaze.
//http://wiki.unity3d.com/index.php?title=Texture_Mask
//----------------------------------------------------------------

Shader "MaskedTexture"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
	_Mask("Culling Mask", 2D) = "white" {}
	_Cutoff("Alpha cutoff", Range(0,1)) = 0.1
	}
		SubShader
	{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
		Lighting Off
		Cull Off
		ZTest Always
		ZWrite Off
		Fog {Mode Off}
		Blend SrcAlpha OneMinusSrcAlpha
		AlphaTest GEqual[_Cutoff]
		Pass
	{
		SetTexture[_Mask]{ combine texture }
		SetTexture[_MainTex]{ combine texture, previous }
	}
	}
}
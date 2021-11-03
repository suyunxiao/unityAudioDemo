// MatCap Shader, (c) 2015-2019 Jean Moreno

Shader "MatCap/Vertex/Textured Multiply Eye Bring"
{
	Properties
	{
		_Color("Main Color(RGB)",Color)=(0.3,0.3,0.3,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_MatCap ("MatCap (RGB)", 2D) = "white" {}

        // 眨眼相关
        _EyeClosed ("EyeClosed", 2D) = "white" {}
        _Cycle ("眨眼周期(单位:秒)", Float) = 2
        _ClosedTime ("每次眨眼闭眼时间", Float) = 0.1
        _TimeOffset ("时间偏移", Float) = 0.5
	}
	
	Subshader
	{
		Tags { "RenderType"="Opaque" }
		Cull Off
		Pass
		{
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest
				#pragma multi_compile_fog
				#include "UnityCG.cginc"
				
				struct v2f
				{
					float4 pos	: SV_POSITION;
					float2 uv 	: TEXCOORD0;
					float2 cap	: TEXCOORD1;
					UNITY_FOG_COORDS(2)
				};
				
				uniform float4 _MainTex_ST;
				
				v2f vert (appdata_base v)
				{
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
					half2 capCoord;
					
					float3 worldNorm = normalize(unity_WorldToObject[0].xyz * v.normal.x + unity_WorldToObject[1].xyz * v.normal.y + unity_WorldToObject[2].xyz * v.normal.z);
					worldNorm = mul((float3x3)UNITY_MATRIX_V, worldNorm);
					o.cap.xy = worldNorm.xy * 0.5 + 0.5;
					
					UNITY_TRANSFER_FOG(o, o.pos);

					return o;
				}
				
				uniform float4 _Color;
				uniform sampler2D _MainTex;
				uniform sampler2D _MatCap;

                // 眨眼相关
                uniform sampler2D _EyeClosed;
                uniform float _Cycle;
                uniform float _ClosedTime;
                uniform float _TimeOffset;
				
				fixed4 frag (v2f i) : COLOR
				{
					fixed4 standardTex = tex2D(_MainTex, i.uv);
                    fixed4 eyeTex = tex2D(_EyeClosed, i.uv);
                    fixed num = (_Time.y + _TimeOffset) % _Cycle;
                    float standardWeight = step(_ClosedTime, num);
                    fixed4 tex = standardTex * standardWeight + eyeTex * (1 - standardWeight);

					fixed4 mc = tex2D(_MatCap, i.cap) * tex * unity_ColorSpaceDouble*_Color;
					UNITY_APPLY_FOG(i.fogCoord, mc);

					return mc;
				}
			ENDCG
		}
	}
	
	Fallback "VertexLit"
}

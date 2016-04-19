﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET.Builders
{
    
    class CSProjectBuilder
    {
        private string _base = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            "<Project ToolsVersion=\"14.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">" +
            "  <Import Project=\"$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props\" Condition=\"Exists('$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props')\" />" +
            "  <PropertyGroup>" +
            "    <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>" +
            "    <Platform Condition=\" '$(Platform)' == '' \">AnyCPU</Platform>" +
            "    <ProjectGuid>{5D20C10A-04F8-4525-A4B4-7860333CD9BA}</ProjectGuid>" +
            "    <OutputType>WinExe</OutputType>" +
            "    <AppDesignerFolder>Properties</AppDesignerFolder>" +
            "    <RootNamespace>XXXX</RootNamespace>" +
            "    <AssemblyName>XXXX</AssemblyName>" +
            "    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>" +
            "    <FileAlignment>512</FileAlignment>" +
            "    <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>" +
            "  </PropertyGroup>" +
            "  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' \">" +
            "    <PlatformTarget>AnyCPU</PlatformTarget>" +
            "    <DebugSymbols>true</DebugSymbols>" +
            "    <DebugType>full</DebugType>" +
            "    <Optimize>false</Optimize>" +
            "    <OutputPath>bin\\Debug\\</OutputPath>" +
            "    <DefineConstants>DEBUG;TRACE</DefineConstants>" +
            "    <ErrorReport>prompt</ErrorReport>" +
            "    <WarningLevel>4</WarningLevel>" +
            "  </PropertyGroup>" +
            "  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' \">" +
            "    <PlatformTarget>AnyCPU</PlatformTarget>" +
            "    <DebugType>pdbonly</DebugType>" +
            "    <Optimize>true</Optimize>" +
            "    <OutputPath>bin\\Release\\</OutputPath>" +
            "    <DefineConstants>TRACE</DefineConstants>" +
            "    <ErrorReport>prompt</ErrorReport>" +
            "    <WarningLevel>4</WarningLevel>" +
            "  </PropertyGroup>" +
            "  <ItemGroup>" +
            "    <Reference Include=\"System\" />" +
            "    <Reference Include=\"System.Core\" />" +
            "    <Reference Include=\"System.Xml.Linq\" />" +
            "    <Reference Include=\"System.Data.DataSetExtensions\" />" +
            "    <Reference Include=\"Microsoft.CSharp\" />" +
            "    <Reference Include=\"System.Data\" />" +
            "    <Reference Include=\"System.Deployment\" />" +
            "    <Reference Include=\"System.Drawing\" />" +
            "    <Reference Include=\"System.Net.Http\" />" +
            "    <Reference Include=\"System.Windows.Forms\" />" +
            "    <Reference Include=\"System.Xml\" />" +
            "  </ItemGroup>" +
            "  <ItemGroup>" +
            "    <Compile Include=\"Form1.cs\">" +
            "      <SubType>Form</SubType>" +
            "    </Compile>" +
            "    <Compile Include=\"Form1.Designer.cs\">" +
            "      <DependentUpon>Form1.cs</DependentUpon>" +
            "    </Compile>" +
            "    <Compile Include=\"Program.cs\" />" +
            "    <Compile Include=\"Properties\\AssemblyInfo.cs\" />" +
            "    <EmbeddedResource Include=\"Properties\\Resources.resx\">" +
            "      <Generator>ResXFileCodeGenerator</Generator>" +
            "      <LastGenOutput>Resources.Designer.cs</LastGenOutput>" +
            "      <SubType>Designer</SubType>" +
            "    </EmbeddedResource>" +
            "    <Compile Include=\"Properties\\Resources.Designer.cs\">" +
            "      <AutoGen>True</AutoGen>" +
            "      <DependentUpon>Resources.resx</DependentUpon>" +
            "    </Compile>" +
            "    <None Include=\"Properties\\Settings.settings\">" +
            "      <Generator>SettingsSingleFileGenerator</Generator>" +
            "      <LastGenOutput>Settings.Designer.cs</LastGenOutput>" +
            "    </None>" +
            "    <Compile Include=\"Properties\\Settings.Designer.cs\">" +
            "      <AutoGen>True</AutoGen>" +
            "      <DependentUpon>Settings.settings</DependentUpon>" +
            "      <DesignTimeSharedInput>True</DesignTimeSharedInput>" +
            "    </Compile>" +
            "  </ItemGroup>" +
            "  <ItemGroup>" +
            "    <None Include=\"App.config\" />" +
            "  </ItemGroup>" +
            "  <Import Project=\"$(MSBuildToolsPath)\\Microsoft.CSharp.targets\" />" +
            "  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. " +
            "       Other similar extension points exist, see Microsoft.Common.targets." +
            "  <Target Name=\"BeforeBuild\">" +
            "  </Target>" +
            "  <Target Name=\"AfterBuild\">" +
            "  </Target>" +
            "  -->" +
            "</Project>";
    }
}
